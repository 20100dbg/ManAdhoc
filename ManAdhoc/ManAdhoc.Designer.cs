namespace ManAdhoc
{
    partial class ManAdhoc
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_networks = new System.Windows.Forms.ListView();
            this.IsConnected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_security = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.réseauxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerAdhocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_networks
            // 
            this.lv_networks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_networks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IsConnected,
            this.col_name,
            this.col_security,
            this.col_type});
            this.lv_networks.FullRowSelect = true;
            this.lv_networks.GridLines = true;
            this.lv_networks.Location = new System.Drawing.Point(12, 27);
            this.lv_networks.MultiSelect = false;
            this.lv_networks.Name = "lv_networks";
            this.lv_networks.Size = new System.Drawing.Size(422, 197);
            this.lv_networks.TabIndex = 11;
            this.lv_networks.UseCompatibleStateImageBehavior = false;
            this.lv_networks.View = System.Windows.Forms.View.Details;
            // 
            // IsConnected
            // 
            this.IsConnected.Text = "";
            this.IsConnected.Width = 20;
            // 
            // col_name
            // 
            this.col_name.Text = "Name";
            this.col_name.Width = 160;
            // 
            // col_security
            // 
            this.col_security.Text = "Security";
            this.col_security.Width = 101;
            // 
            // col_type
            // 
            this.col_type.Text = "Type";
            this.col_type.Width = 135;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réseauxToolStripMenuItem,
            this.profilsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // réseauxToolStripMenuItem
            // 
            this.réseauxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerAdhocToolStripMenuItem,
            this.connecterToolStripMenuItem,
            this.déconnecterToolStripMenuItem});
            this.réseauxToolStripMenuItem.Name = "réseauxToolStripMenuItem";
            this.réseauxToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.réseauxToolStripMenuItem.Text = "Réseaux";
            // 
            // créerAdhocToolStripMenuItem
            // 
            this.créerAdhocToolStripMenuItem.Name = "créerAdhocToolStripMenuItem";
            this.créerAdhocToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.créerAdhocToolStripMenuItem.Text = "Créer Adhoc";
            this.créerAdhocToolStripMenuItem.Click += new System.EventHandler(this.créerAdhocToolStripMenuItem_Click);
            // 
            // connecterToolStripMenuItem
            // 
            this.connecterToolStripMenuItem.Name = "connecterToolStripMenuItem";
            this.connecterToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.connecterToolStripMenuItem.Text = "Connecter";
            this.connecterToolStripMenuItem.Click += new System.EventHandler(this.connecterToolStripMenuItem_Click);
            // 
            // déconnecterToolStripMenuItem
            // 
            this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
            this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.déconnecterToolStripMenuItem.Text = "Déconnecter";
            this.déconnecterToolStripMenuItem.Click += new System.EventHandler(this.déconnecterToolStripMenuItem_Click);
            // 
            // profilsToolStripMenuItem
            // 
            this.profilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerToolStripMenuItem,
            this.exporterToolStripMenuItem});
            this.profilsToolStripMenuItem.Name = "profilsToolStripMenuItem";
            this.profilsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.profilsToolStripMenuItem.Text = "Profils";
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importerToolStripMenuItem.Text = "Importer";
            this.importerToolStripMenuItem.Click += new System.EventHandler(this.importerToolStripMenuItem_Click);
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exporterToolStripMenuItem.Text = "Exporter";
            this.exporterToolStripMenuItem.Click += new System.EventHandler(this.exporterToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 227);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(446, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_label
            // 
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(0, 17);
            // 
            // ManAdhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 249);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lv_networks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManAdhoc";
            this.Text = "ManAdhoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManAdhoc_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_networks;
        private System.Windows.Forms.ColumnHeader col_name;
        private System.Windows.Forms.ColumnHeader col_security;
        private System.Windows.Forms.ColumnHeader col_type;
        private System.Windows.Forms.ColumnHeader IsConnected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem réseauxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créerAdhocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
    }
}

