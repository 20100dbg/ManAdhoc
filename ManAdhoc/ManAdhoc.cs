using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ManAdhoc
{
    public partial class ManAdhoc : Form
    {
        Process cmd = new Process();
        List<Network> networks = new List<Network>();
        String HIDDEN_SSID_NAME = "[Hidden SSID]";
        String PROFILE_NAME = "ManAdhoc";
        Thread tRefresh;
        Boolean refreshGui = true;

        public ManAdhoc()
        {
            InitializeComponent();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.Verb = "runas";
            cmd.Start();

            cmd.StandardInput.WriteLine("netsh wlan add profile "+ PROFILE_NAME +".xml");
          
            tRefresh = new Thread(new ThreadStart(AutoRefresh));
            tRefresh.Start();
        }


        public void AutoRefresh()
        {
            do
            {
                ListNetworks();
                RefreshNetworksList();

                String ssidConnected = GetCurrentNetwork();
                if (!String.IsNullOrEmpty(ssidConnected)) this.UIThread(() => status_label.Text = "Connecté à " + ssidConnected);
                else this.UIThread(() => status_label.Text = "Non connecté");

                Thread.Sleep(2000);
            } while (refreshGui);
        }


        public List<Network> ListNetworks()
        {
            String ssidConnected = GetCurrentNetwork();

            networks.Clear();
            cmd.StandardInput.WriteLine("netsh wlan show networks && echo ___");
            String line;

            while (!cmd.StandardOutput.ReadLine().StartsWith("Interface name")) ;

            do
            {
                line = cmd.StandardOutput.ReadLine();

                if (line.StartsWith("SSID"))
                {
                    String name = line.Substring(line.IndexOf(':') + 2);
                    networks.Add(new Network { IsConnected = (!String.IsNullOrEmpty(ssidConnected) && ssidConnected == name), Name = name, Key = "", Encryption = "", Security = "", Type = "" });
                    if (String.IsNullOrEmpty(networks[networks.Count - 1].Name)) networks[networks.Count - 1].Name = HIDDEN_SSID_NAME;
                }
                if (line.Trim().StartsWith("Network type")) networks[networks.Count - 1].Type = line.Substring(line.IndexOf(':') + 2);
                if (line.Trim().StartsWith("Authentication")) networks[networks.Count - 1].Security = line.Substring(line.IndexOf(':') + 2);
                if (line.Trim().StartsWith("Encryption"))  networks[networks.Count - 1].Encryption = line.Substring(line.IndexOf(':') + 2);

            } while (line != "___");

            return networks;
        }


        public void RefreshNetworksList()
        {
            /*
            this.UIThread(() => lv_networks.Items.Clear());
            
            for (int i = 0; i < networks.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(networks[i].ToListViewItemArray());
                this.UIThread(() => lv_networks.Items.Add(lvi));                    
            }
            */
            
            this.UIThread(() =>
            {
                //suppression


                for (int i = 0; i < lv_networks.Items.Count; i++)
                {
                    Boolean flag = false;

                    for (int j = 0; j < networks.Count; j++)
                    {
                        ListViewItem lvi = lv_networks.Items[i];
                        if (lvi.SubItems[1].Text == networks[j].Name) flag = true;
                    }

                    if (!flag) lv_networks.Items.RemoveAt(i--);
                }


                //ajout
                for (int j = 0; j < networks.Count; j++)
                {
                    Boolean flag = false;

                    for (int i = 0; i < lv_networks.Items.Count; i++)
                    {
                        ListViewItem lvi = lv_networks.Items[i];
                        if (lvi.SubItems[1].Text == networks[j].Name) flag = true;
                    }

                    if (!flag)
                    {
                        ListViewItem lvi = new ListViewItem(networks[j].ToListViewItemArray());
                        lv_networks.Items.Add(lvi);
                    }
                }
            });
            

        }


        public String GetPassKey(String ssid)
        {
            cmd.StandardInput.WriteLine("netsh wlan show profile name=" + ssid + " key=clear && echo ___");

            String passkey = "", line;
            Boolean flag = false;
            do
            {
                line = cmd.StandardOutput.ReadLine();

                if (line.Contains("Key Content"))
                {
                    passkey = line.Substring(line.IndexOf(':') + 2);
                    flag = true;
                }
                else if (line.Contains("not found on the system")) flag = true;
                else if (line == "___") flag = true;

            } while (!flag);
            
            if (String.IsNullOrEmpty(passkey))
                passkey = Prompt.ShowDialog("Passkey to connect to " + ssid, "Passkey to connect to " + ssid);

            return passkey;
        }


        public void JoinNetwork(Network ntwk)
        {
            //IBSS = adhoc, ESS = infra
            cmd.StandardInput.WriteLine("netsh wlan set profileparameter name=" + PROFILE_NAME + " SSIDname=" + ntwk.Name + " connectionType=" + ((ntwk.Type == "Adhoc") ? "IBSS":"ESS"));

            if (ntwk.Key.Length > 0)
                cmd.StandardInput.WriteLine("netsh wlan set profileparameter name=" + PROFILE_NAME + " authentication=WPA2PSK encryption=AES keyType=passphrase useOneX=no keyMaterial=" + ntwk.Key);


            ReadToEnd();
            cmd.StandardInput.WriteLine("netsh wlan connect name=" + PROFILE_NAME + " ssid=" + ntwk.Name);

            String line = ReadToEnd(); //cmd.StandardOutput.ReadLine();

            if (line.Contains("Connection request was completed successfully"))
                this.UIThread(() => this.status_label.Text = "Connexion en cours...");
            else
                this.UIThread(() => this.status_label.Text = "Connexion impossible");

            //is nots available to connect
            //connection request was completed successfully
        }

        public void Disconnect()
        {
            cmd.StandardInput.WriteLine("netsh wlan disconnect");
            this.UIThread(() => this.status_label.Text = "Déconnexion...");
        }

        public void DeleteProfile()
        {
            cmd.StandardInput.WriteLine("netsh wlan delete profile name=" + PROFILE_NAME);
            this.UIThread(() => this.status_label.Text = "Profil " + PROFILE_NAME + " supprimé");
        }

        public String ReadToEnd()
        {
            String line = "", text = "";

            cmd.StandardInput.WriteLine("echo ___");
            do
            {
                text += line + Environment.NewLine;
                line = cmd.StandardOutput.ReadLine();
            } while (line != "___") ;
            
            return text;
        }


        public void ExportProfile(String profil)
        {
            cmd.StandardInput.WriteLine("netsh wlan export profile " + profil);
            this.UIThread(() => this.status_label.Text = "Profil " + profil + " exporté");
        }


        public void ImportProfile(String filename)
        {
            cmd.StandardInput.WriteLine("netsh wlan add profile \"" + filename + "\"");
            this.UIThread(() => this.status_label.Text = "Profil " + Path.GetFileName(filename) + " importé");
        }

        
        public String GetStatus()
        {
            cmd.StandardInput.WriteLine("netsh wlan show interfaces && echo ___");
            String line, state = "";

            do
            {
                line = cmd.StandardOutput.ReadLine();
                
                if (line.Trim().StartsWith("State"))
                    state = line.Substring(line.IndexOf(':') + 2);

            } while (line != "___");

            return state;
        }


        public String GetCurrentNetwork()
        {
            ReadToEnd();
            cmd.StandardInput.WriteLine("netsh wlan show interfaces && echo ___");
            String line, ssid = "";
            Boolean IsConnected = false;

            do
            {
                line = cmd.StandardOutput.ReadLine();

                String[] tab = line.Split(new char[] {':'}, 2);
                if (tab[0].Trim() == "State") IsConnected = (tab[1].Trim() == "connected");
                if (tab[0].Trim() == "SSID") ssid = tab[1].Trim();

            } while (line != "___");

            if (!IsConnected) ssid = null;
            return ssid;
        }


        public static String GetShortSecurity(String sec)
        {
            if (sec.StartsWith("WPA2")) return "WPA2";
            else if (sec.StartsWith("WPA")) return "WPA";
            else if (sec.StartsWith("WEP")) return "WEP";
            else return "OPN";
        }


        private void ManAdhoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DeleteProfile();
            refreshGui = false;
            tRefresh.Abort();

            cmd.StandardInput.Close();
            cmd.StandardOutput.Close();
            cmd.Close();
        }


        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.InitialDirectory = Environment.CurrentDirectory;
                opf.ShowDialog();

                if (!String.IsNullOrEmpty(opf.FileName))
                {
                    String folderImport = Path.GetDirectoryName(opf.FileName);

                    if (folderImport != Environment.CurrentDirectory)
                    {
                        File.Copy(opf.FileName, Path.GetFileName(opf.FileName));
                    }

                    ImportProfile(opf.FileName);
                }
            }
        }


        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String profil = Prompt.ShowDialog("Nom du profil : ", "Export de profil");
            ExportProfile(profil);
        }


        private void connecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idx = -1;
            if (lv_networks.SelectedIndices.Count > 0) idx = lv_networks.SelectedIndices[0];

            if (idx > -1)
            {
                if (networks[idx].Name == HIDDEN_SSID_NAME)
                    networks[idx].Name = Prompt.ShowDialog("SSID", "SSID to connect : ");

                if (networks[idx].Security != "Open")
                    networks[idx].Key = GetPassKey(networks[idx].Name);

                JoinNetwork(networks[idx]);
            }
        }

        private void déconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void créerAdhocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAdhoc ca = new CreateAdhoc(this);
            ca.ShowDialog();
        }

    }


    public class Network
    {
        public String Name { get; set; }
        public String Key { get; set; }

        public String Type { get; set; }
        public String Security { get; set; }
        public String Encryption { get; set; }

        public Boolean IsConnected { get; set; }

        public Network()
        {

        }

        public String[] ToListViewItemArray()
        {
            return new String[] { ((IsConnected) ? "*" : ""), Name, ManAdhoc.GetShortSecurity(Security), Type };
        }

        public override string ToString()
        {
            return Name + " ("+ ManAdhoc.GetShortSecurity(Security) +")";
        }
    }


    public static class Prompt
    {
        public static String ShowDialog(String text, String caption)
        {
            String myValue = null;
            Form prompt = new Form();
            prompt.Width = 250;
            prompt.Height = 150;
            prompt.Text = caption;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.MinimizeBox = false;
            prompt.MaximizeBox = false;
            prompt.KeyPreview = true;

            Label textLabel = new Label() { Left = 10, Top = 20, Text = text, Width = 250 };
            Button confirmation = new Button() { Text = "Valider", Left = 70, Width = 80, Top = 80 };
            TextBox textBox = new TextBox() { Left = 40, Top = 50, Width = 150 };
            textBox.Focus();

            confirmation.Click += (sender, e) => { myValue = textBox.Text; prompt.Close(); };
            prompt.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Escape) { prompt.Close(); } };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();

            return myValue;
        }
    }


    public static class ControlExtensions
    {
        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
                @this.BeginInvoke(code);
            else
                code.Invoke();
        }
    }

}
