using System;
using System.Windows.Forms;

namespace ManAdhoc
{
    public partial class CreateAdhoc : Form
    {

        ManAdhoc parent;

        public CreateAdhoc(ManAdhoc ma)
        {
            InitializeComponent();
            this.parent = ma;
        }

        private void b_create_Click(object sender, EventArgs e)
        {
            Network ntwk = new Network { Name = tb_ssid.Text, Key = tb_key.Text, Type = "Adhoc" };
            parent.JoinNetwork(ntwk);
        }
    }
}
