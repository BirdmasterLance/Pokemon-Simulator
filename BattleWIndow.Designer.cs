namespace Pokemon_Simulator.Properties
{
    partial class BattleWindow
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
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.Move1 = new System.Windows.Forms.Button();
            this.Move2 = new System.Windows.Forms.Button();
            this.Move3 = new System.Windows.Forms.Button();
            this.Move4 = new System.Windows.Forms.Button();
            this.EnemyName = new System.Windows.Forms.Label();
            this.PlayerPokemon = new System.Windows.Forms.Label();
            this.PlayerHealth = new System.Windows.Forms.Label();
            this.playerPokemonImage = new System.Windows.Forms.PictureBox();
            this.enemyPokemonImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(781, 32);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(327, 28);
            this.progressBar2.TabIndex = 1;
            this.progressBar2.Value = 100;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(282, 97);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(327, 28);
            this.progressBar3.TabIndex = 2;
            this.progressBar3.Value = 50;
            // 
            // Move1
            // 
            this.Move1.BackColor = System.Drawing.SystemColors.Control;
            this.Move1.Location = new System.Drawing.Point(905, 484);
            this.Move1.Name = "Move1";
            this.Move1.Size = new System.Drawing.Size(203, 70);
            this.Move1.TabIndex = 3;
            this.Move1.Text = "Move1";
            this.Move1.UseVisualStyleBackColor = false;
            this.Move1.Click += new System.EventHandler(this.Move1_Click);
            // 
            // Move2
            // 
            this.Move2.Location = new System.Drawing.Point(1114, 484);
            this.Move2.Name = "Move2";
            this.Move2.Size = new System.Drawing.Size(203, 70);
            this.Move2.TabIndex = 4;
            this.Move2.Text = "Move2";
            this.Move2.UseVisualStyleBackColor = true;
            this.Move2.Click += new System.EventHandler(this.Move2_Click);
            // 
            // Move3
            // 
            this.Move3.Location = new System.Drawing.Point(905, 560);
            this.Move3.Name = "Move3";
            this.Move3.Size = new System.Drawing.Size(203, 70);
            this.Move3.TabIndex = 5;
            this.Move3.Text = "Move3";
            this.Move3.UseVisualStyleBackColor = true;
            this.Move3.Click += new System.EventHandler(this.Move3_Click);
            // 
            // Move4
            // 
            this.Move4.Location = new System.Drawing.Point(1116, 560);
            this.Move4.Name = "Move4";
            this.Move4.Size = new System.Drawing.Size(203, 70);
            this.Move4.TabIndex = 6;
            this.Move4.Text = "Move4";
            this.Move4.UseVisualStyleBackColor = true;
            this.Move4.Click += new System.EventHandler(this.Move4_Click);
            // 
            // EnemyName
            // 
            this.EnemyName.AutoSize = true;
            this.EnemyName.Location = new System.Drawing.Point(793, 12);
            this.EnemyName.Name = "EnemyName";
            this.EnemyName.Size = new System.Drawing.Size(110, 16);
            this.EnemyName.TabIndex = 7;
            this.EnemyName.Text = "Enemy Pokemon";
            // 
            // PlayerPokemon
            // 
            this.PlayerPokemon.AutoSize = true;
            this.PlayerPokemon.Location = new System.Drawing.Point(295, 78);
            this.PlayerPokemon.Name = "PlayerPokemon";
            this.PlayerPokemon.Size = new System.Drawing.Size(107, 16);
            this.PlayerPokemon.TabIndex = 8;
            this.PlayerPokemon.Text = "Player Pokemon";
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.AutoSize = true;
            this.PlayerHealth.Location = new System.Drawing.Point(550, 128);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(52, 16);
            this.PlayerHealth.TabIndex = 9;
            this.PlayerHealth.Text = "50 / 100";
            // 
            // playerPokemonImage
            // 
            this.playerPokemonImage.Location = new System.Drawing.Point(348, 153);
            this.playerPokemonImage.Name = "playerPokemonImage";
            this.playerPokemonImage.Size = new System.Drawing.Size(193, 274);
            this.playerPokemonImage.TabIndex = 10;
            this.playerPokemonImage.TabStop = false;
            // 
            // enemyPokemonImage
            // 
            this.enemyPokemonImage.Location = new System.Drawing.Point(848, 66);
            this.enemyPokemonImage.Name = "enemyPokemonImage";
            this.enemyPokemonImage.Size = new System.Drawing.Size(193, 274);
            this.enemyPokemonImage.TabIndex = 11;
            this.enemyPokemonImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(656, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // BattleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1329, 641);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enemyPokemonImage);
            this.Controls.Add(this.playerPokemonImage);
            this.Controls.Add(this.PlayerHealth);
            this.Controls.Add(this.PlayerPokemon);
            this.Controls.Add(this.EnemyName);
            this.Controls.Add(this.Move4);
            this.Controls.Add(this.Move3);
            this.Controls.Add(this.Move2);
            this.Controls.Add(this.Move1);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Name = "BattleWindow";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BattleWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Button Move1;
        private System.Windows.Forms.Button Move2;
        private System.Windows.Forms.Button Move4;
        private System.Windows.Forms.Button Move3;
        private System.Windows.Forms.Label EnemyName;
        private System.Windows.Forms.Label PlayerPokemon;
        private System.Windows.Forms.Label PlayerHealth;
        private System.Windows.Forms.PictureBox playerPokemonImage;
        private System.Windows.Forms.PictureBox enemyPokemonImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}