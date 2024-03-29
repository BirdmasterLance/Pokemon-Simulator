﻿namespace Pokemon_Simulator
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
            this.components = new System.ComponentModel.Container();
            this.BTStart = new System.Windows.Forms.Button();
            this.PkmnList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartyPkmn = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PbCharacterPic = new System.Windows.Forms.PictureBox();
            this.LblName = new System.Windows.Forms.Label();
            this.LblSlogan = new System.Windows.Forms.Label();
            this.CharacterArea = new System.Windows.Forms.Splitter();
            this.label5 = new System.Windows.Forms.Label();
            this.LblHP = new System.Windows.Forms.Label();
            this.GbTats = new System.Windows.Forms.GroupBox();
            this.LblType = new System.Windows.Forms.Label();
            this.LblSpeed = new System.Windows.Forms.Label();
            this.LblSpDefense = new System.Windows.Forms.Label();
            this.LblSpAttack = new System.Windows.Forms.Label();
            this.LblDefense = new System.Windows.Forms.Label();
            this.LblAttack = new System.Windows.Forms.Label();
            this.addPokemonButton = new System.Windows.Forms.Button();
            this.removePokemonButton = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnItem = new System.Windows.Forms.Button();
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
            this.BTStart.Location = new System.Drawing.Point(988, 408);
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
            this.PkmnList.SelectedIndexChanged += new System.EventHandler(this.PkmnList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.PartyPkmn.SelectedIndexChanged += new System.EventHandler(this.PartyPkmn_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "Party Pokemon";
            // 
            // PbCharacterPic
            // 
            this.PbCharacterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbCharacterPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbCharacterPic.Cursor = System.Windows.Forms.Cursors.Default;
            this.PbCharacterPic.Location = new System.Drawing.Point(811, 10);
            this.PbCharacterPic.Name = "PbCharacterPic";
            this.PbCharacterPic.Size = new System.Drawing.Size(240, 240);
            this.PbCharacterPic.TabIndex = 8;
            this.PbCharacterPic.TabStop = false;
            // 
            // LblName
            // 
            this.LblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.CadetBlue;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LblName.ForeColor = System.Drawing.Color.LightCyan;
            this.LblName.Location = new System.Drawing.Point(880, 270);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(85, 38);
            this.LblName.TabIndex = 9;
            this.LblName.Text = "名字";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSlogan
            // 
            this.LblSlogan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSlogan.BackColor = System.Drawing.Color.CadetBlue;
            this.LblSlogan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LblSlogan.ForeColor = System.Drawing.Color.LightCyan;
            this.LblSlogan.Location = new System.Drawing.Point(813, 320);
            this.LblSlogan.Name = "LblSlogan";
            this.LblSlogan.Size = new System.Drawing.Size(576, 85);
            this.LblSlogan.TabIndex = 9;
            this.LblSlogan.Text = "\"お腹が空くです“";
            this.LblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharacterArea
            // 
            this.CharacterArea.BackColor = System.Drawing.Color.CadetBlue;
            this.CharacterArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CharacterArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.CharacterArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.CharacterArea.Enabled = false;
            this.CharacterArea.Location = new System.Drawing.Point(767, 0);
            this.CharacterArea.Name = "CharacterArea";
            this.CharacterArea.Size = new System.Drawing.Size(631, 519);
            this.CharacterArea.TabIndex = 0;
            this.CharacterArea.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(702, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "label4";
            // 
            // LblHP
            // 
            this.LblHP.AutoSize = true;
            this.LblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHP.Location = new System.Drawing.Point(6, 31);
            this.LblHP.Name = "LblHP";
            this.LblHP.Size = new System.Drawing.Size(52, 29);
            this.LblHP.TabIndex = 10;
            this.LblHP.Text = "HP:";
            // 
            // GbTats
            // 
            this.GbTats.BackColor = System.Drawing.Color.CadetBlue;
            this.GbTats.Controls.Add(this.LblType);
            this.GbTats.Controls.Add(this.LblSpeed);
            this.GbTats.Controls.Add(this.LblSpDefense);
            this.GbTats.Controls.Add(this.LblSpAttack);
            this.GbTats.Controls.Add(this.LblDefense);
            this.GbTats.Controls.Add(this.LblAttack);
            this.GbTats.Controls.Add(this.LblHP);
            this.GbTats.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbTats.Location = new System.Drawing.Point(1069, 10);
            this.GbTats.Name = "GbTats";
            this.GbTats.Size = new System.Drawing.Size(320, 240);
            this.GbTats.TabIndex = 12;
            this.GbTats.TabStop = false;
            this.GbTats.Text = "Stats";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.Location = new System.Drawing.Point(6, 204);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(74, 29);
            this.LblType.TabIndex = 16;
            this.LblType.Text = "Type:";
            // 
            // LblSpeed
            // 
            this.LblSpeed.AutoSize = true;
            this.LblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSpeed.Location = new System.Drawing.Point(6, 176);
            this.LblSpeed.Name = "LblSpeed";
            this.LblSpeed.Size = new System.Drawing.Size(91, 29);
            this.LblSpeed.TabIndex = 15;
            this.LblSpeed.Text = "Speed:";
            // 
            // LblSpDefense
            // 
            this.LblSpDefense.AutoSize = true;
            this.LblSpDefense.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSpDefense.Location = new System.Drawing.Point(6, 147);
            this.LblSpDefense.Name = "LblSpDefense";
            this.LblSpDefense.Size = new System.Drawing.Size(98, 29);
            this.LblSpDefense.TabIndex = 14;
            this.LblSpDefense.Text = "Sp. Def:";
            // 
            // LblSpAttack
            // 
            this.LblSpAttack.AutoSize = true;
            this.LblSpAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSpAttack.Location = new System.Drawing.Point(6, 118);
            this.LblSpAttack.Name = "LblSpAttack";
            this.LblSpAttack.Size = new System.Drawing.Size(94, 29);
            this.LblSpAttack.TabIndex = 13;
            this.LblSpAttack.Text = "Sp. Atk:";
            // 
            // LblDefense
            // 
            this.LblDefense.AutoSize = true;
            this.LblDefense.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDefense.Location = new System.Drawing.Point(6, 89);
            this.LblDefense.Name = "LblDefense";
            this.LblDefense.Size = new System.Drawing.Size(56, 29);
            this.LblDefense.TabIndex = 12;
            this.LblDefense.Text = "Def:";
            // 
            // LblAttack
            // 
            this.LblAttack.AutoSize = true;
            this.LblAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAttack.Location = new System.Drawing.Point(6, 60);
            this.LblAttack.Name = "LblAttack";
            this.LblAttack.Size = new System.Drawing.Size(52, 29);
            this.LblAttack.TabIndex = 11;
            this.LblAttack.Text = "Atk:";
            // 
            // addPokemonButton
            // 
            this.addPokemonButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addPokemonButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.addPokemonButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.addPokemonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPokemonButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.addPokemonButton.Location = new System.Drawing.Point(103, 392);
            this.addPokemonButton.Name = "addPokemonButton";
            this.addPokemonButton.Size = new System.Drawing.Size(210, 80);
            this.addPokemonButton.TabIndex = 13;
            this.addPokemonButton.Text = "Add";
            this.addPokemonButton.UseVisualStyleBackColor = false;
            this.addPokemonButton.Click += new System.EventHandler(this.addPokemonButton_Click);
            // 
            // removePokemonButton
            // 
            this.removePokemonButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removePokemonButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.removePokemonButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.removePokemonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePokemonButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.removePokemonButton.Location = new System.Drawing.Point(391, 392);
            this.removePokemonButton.Name = "removePokemonButton";
            this.removePokemonButton.Size = new System.Drawing.Size(210, 80);
            this.removePokemonButton.TabIndex = 14;
            this.removePokemonButton.Text = "Remove";
            this.removePokemonButton.UseVisualStyleBackColor = false;
            this.removePokemonButton.Click += new System.EventHandler(this.removePokemonButton_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnBack.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnBack.Location = new System.Drawing.Point(811, 415);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(123, 57);
            this.BtnBack.TabIndex = 15;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.BattleRun);
            // 
            // BtnItem
            // 
            this.BtnItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnItem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnItem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnItem.Location = new System.Drawing.Point(1175, 256);
            this.BtnItem.Name = "BtnItem";
            this.BtnItem.Size = new System.Drawing.Size(123, 57);
            this.BtnItem.TabIndex = 16;
            this.BtnItem.Text = "Item";
            this.BtnItem.UseVisualStyleBackColor = false;
            this.BtnItem.Click += new System.EventHandler(this.BtnItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1398, 519);
            this.Controls.Add(this.BtnItem);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.removePokemonButton);
            this.Controls.Add(this.addPokemonButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblSlogan);
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
        //private System.Windows.Forms.PictureBox picture1v1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Splitter CharacterArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblHP;
        private System.Windows.Forms.GroupBox GbTats;
        private System.Windows.Forms.Button addPokemonButton;
        private System.Windows.Forms.Button removePokemonButton;
        private System.Windows.Forms.Label LblSpeed;
        private System.Windows.Forms.Label LblSpDefense;
        private System.Windows.Forms.Label LblSpAttack;
        private System.Windows.Forms.Label LblDefense;
        private System.Windows.Forms.Label LblAttack;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblSlogan;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnItem;
    }
}

