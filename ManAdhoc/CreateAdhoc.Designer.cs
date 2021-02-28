namespace ManAdhoc
{
    partial class CreateAdhoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ssid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_create = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ssid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_key);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.b_create);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 134);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer un réseau Adhoc";
            // 
            // tb_ssid
            // 
            this.tb_ssid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ssid.Location = new System.Drawing.Point(48, 25);
            this.tb_ssid.Name = "tb_ssid";
            this.tb_ssid.Size = new System.Drawing.Size(265, 20);
            this.tb_ssid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SSID";
            // 
            // tb_key
            // 
            this.tb_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_key.Location = new System.Drawing.Point(48, 50);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(265, 20);
            this.tb_key.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // b_create
            // 
            this.b_create.Location = new System.Drawing.Point(253, 108);
            this.b_create.Name = "b_create";
            this.b_create.Size = new System.Drawing.Size(60, 20);
            this.b_create.TabIndex = 8;
            this.b_create.Text = "Créer";
            this.b_create.UseVisualStyleBackColor = true;
            this.b_create.Click += new System.EventHandler(this.b_create_Click);
            // 
            // CreateAdhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateAdhoc";
            this.Text = "CreateAdhoc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_ssid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_create;
    }
}