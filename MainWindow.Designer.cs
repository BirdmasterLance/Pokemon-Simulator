namespace Pokemon_Simulator
{
    partial class MainWindow
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
            this.BTStart = new System.Windows.Forms.Button();
            this.PkmnList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartyPkmn = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PbCharacterPic = new System.Windows.Forms.PictureBox();
            this.LblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CharacterArea = new System.Windows.Forms.Splitter();
            this.label5 = new System.Windows.Forms.Label();
            this.LblHP = new System.Windows.Forms.Label();
            this.GbTats = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbCharacterPic)).BeginInit();
            this.GbTats.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTStart
            // 
            this.BTStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTStart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BTStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.BTStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTStart.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BTStart.Location = new System.Drawing.Point(991, 408);
            this.BTStart.Name = "BTStart";
            this.BTStart.Size = new System.Drawing.Size(210, 80);
            this.BTStart.TabIndex = 0;
            this.BTStart.Text = "Start";
            this.BTStart.UseVisualStyleBackColor = false;
            this.BTStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // PkmnList
            // 
            this.PkmnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PkmnList.FormattingEnabled = true;
            this.PkmnList.ItemHeight = 20;
            this.PkmnList.Location = new System.Drawing.Point(82, 87);
            this.PkmnList.Name = "PkmnList";
            this.PkmnList.ScrollAlwaysVisible = true;
            this.PkmnList.Size = new System.Drawing.Size(234, 264);
            this.PkmnList.TabIndex = 3;
            this.PkmnList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(58, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pokemon List";
            // 
            // PartyPkmn
            // 
            this.PartyPkmn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PartyPkmn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartyPkmn.FormattingEnabled = true;
            this.PartyPkmn.ItemHeight = 20;
            this.PartyPkmn.Location = new System.Drawing.Point(394, 87);
            this.PartyPkmn.Name = "PartyPkmn";
            this.PartyPkmn.ScrollAlwaysVisible = true;
            this.PartyPkmn.Size = new System.Drawing.Size(234, 264);
            this.PartyPkmn.TabIndex = 6;
            this.PartyPkmn.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.PartyPkmn.SelectedValueChanged += new System.EventHandler(this.updateProfile);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(361, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "Party Pokemon";
            // 
            // PbCharacterPic
            // 
            this.PbCharacterPic.BackgroundImage = global::Pokemon_Simulator.Properties.Resources._3723203;
            this.PbCharacterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbCharacterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbCharacterPic.Cursor = System.Windows.Forms.Cursors.Default;
            this.PbCharacterPic.Location = new System.Drawing.Point(811, 43);
            this.PbCharacterPic.Name = "PbCharacterPic";
            this.PbCharacterPic.Size = new System.Drawing.Size(240, 230);
            this.PbCharacterPic.TabIndex = 8;
            this.PbCharacterPic.TabStop = false;
            // 
            // LblName
            // 
            this.LblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.CadetBlue;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LblName.ForeColor = System.Drawing.Color.LightCyan;
            this.LblName.Location = new System.Drawing.Point(880, 275);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(85, 38);
            this.LblName.TabIndex = 9;
            this.LblName.Text = "咪咪";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.CadetBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.LightCyan;
            this.label3.Location = new System.Drawing.Point(813, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 38);
            this.label3.TabIndex = 9;
            this.label3.Text = "\"お腹が空くです“";
            // 
            // CharacterArea
            // 
            this.CharacterArea.BackColor = System.Drawing.Color.CadetBlue;
            this.CharacterArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CharacterArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.CharacterArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.CharacterArea.Enabled = false;
            this.CharacterArea.Location = new System.Drawing.Point(770, 0);
            this.CharacterArea.Name = "CharacterArea";
            this.CharacterArea.Size = new System.Drawing.Size(631, 518);
            this.CharacterArea.TabIndex = 0;
            this.CharacterArea.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "label4";
            // 
            // LblHP
            // 
            this.LblHP.AutoSize = true;
            this.LblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHP.Location = new System.Drawing.Point(6, 44);
            this.LblHP.Name = "LblHP";
            this.LblHP.Size = new System.Drawing.Size(52, 29);
            this.LblHP.TabIndex = 10;
            this.LblHP.Text = "HP:";
            // 
            // GbTats
            // 
            this.GbTats.BackColor = System.Drawing.Color.CadetBlue;
            this.GbTats.Controls.Add(this.LblHP);
            this.GbTats.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbTats.Location = new System.Drawing.Point(1069, 33);
            this.GbTats.Name = "GbTats";
            this.GbTats.Size = new System.Drawing.Size(320, 240);
            this.GbTats.TabIndex = 12;
            this.GbTats.TabStop = false;
            this.GbTats.Text = "Stats";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1401, 518);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.PbCharacterPic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PartyPkmn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PkmnList);
            this.Controls.Add(this.BTStart);
            this.Controls.Add(this.GbTats);
            this.Controls.Add(this.CharacterArea);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Pokemon Sim Main";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbCharacterPic)).EndInit();
            this.GbTats.ResumeLayout(false);
            this.GbTats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStart;
        private System.Windows.Forms.ListBox PkmnList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PartyPkmn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PbCharacterPic;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter CharacterArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblHP;
        private System.Windows.Forms.GroupBox GbTats;
    }
}

