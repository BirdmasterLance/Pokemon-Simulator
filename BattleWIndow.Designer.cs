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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleWindow));
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.Move1 = new System.Windows.Forms.Button();
            this.Move2 = new System.Windows.Forms.Button();
            this.Move3 = new System.Windows.Forms.Button();
            this.Move4 = new System.Windows.Forms.Button();
            this.EnemyName = new System.Windows.Forms.Label();
            this.PlayerPokemon = new System.Windows.Forms.Label();
            this.PlayerHealth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.enemyPokemonImage = new System.Windows.Forms.PictureBox();
            this.playerPokemonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar2.Location = new System.Drawing.Point(818, 174);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(327, 28);
            this.progressBar2.TabIndex = 1;
            this.progressBar2.Value = 100;
            // 
            // progressBar3
            // 
            this.progressBar3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar3.Location = new System.Drawing.Point(38, 174);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(327, 28);
            this.progressBar3.TabIndex = 2;
            this.progressBar3.Value = 50;
            // 
            // Move1
            // 
            this.Move1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Move1.BackColor = System.Drawing.SystemColors.Control;
            this.Move1.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move1.Location = new System.Drawing.Point(7, 504);
            this.Move1.Name = "Move1";
            this.Move1.Size = new System.Drawing.Size(203, 70);
            this.Move1.TabIndex = 1;
            this.Move1.Text = "Move1";
            this.Move1.UseVisualStyleBackColor = false;
            this.Move1.Click += new System.EventHandler(this.Move1_Click);
            // 
            // Move2
            // 
            this.Move2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Move2.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move2.Location = new System.Drawing.Point(216, 504);
            this.Move2.Name = "Move2";
            this.Move2.Size = new System.Drawing.Size(203, 70);
            this.Move2.TabIndex = 2;
            this.Move2.Text = "Move2";
            this.Move2.UseVisualStyleBackColor = true;
            this.Move2.Click += new System.EventHandler(this.Move2_Click);
            // 
            // Move3
            // 
            this.Move3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Move3.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move3.Location = new System.Drawing.Point(7, 580);
            this.Move3.Name = "Move3";
            this.Move3.Size = new System.Drawing.Size(203, 70);
            this.Move3.TabIndex = 3;
            this.Move3.Text = "Move3";
            this.Move3.UseVisualStyleBackColor = true;
            this.Move3.Click += new System.EventHandler(this.Move3_Click);
            // 
            // Move4
            // 
            this.Move4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Move4.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move4.Location = new System.Drawing.Point(218, 580);
            this.Move4.Name = "Move4";
            this.Move4.Size = new System.Drawing.Size(203, 70);
            this.Move4.TabIndex = 4;
            this.Move4.Text = "Move4";
            this.Move4.UseVisualStyleBackColor = true;
            this.Move4.Click += new System.EventHandler(this.Move4_Click);
            // 
            // EnemyName
            // 
            this.EnemyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnemyName.AutoSize = true;
            this.EnemyName.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.EnemyName.Location = new System.Drawing.Point(813, 141);
            this.EnemyName.Name = "EnemyName";
            this.EnemyName.Size = new System.Drawing.Size(232, 30);
            this.EnemyName.TabIndex = 0;
            this.EnemyName.Text = "Enemy Pokemon";
            // 
            // PlayerPokemon
            // 
            this.PlayerPokemon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlayerPokemon.AutoSize = true;
            this.PlayerPokemon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PlayerPokemon.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PlayerPokemon.Location = new System.Drawing.Point(33, 141);
            this.PlayerPokemon.Name = "PlayerPokemon";
            this.PlayerPokemon.Size = new System.Drawing.Size(242, 30);
            this.PlayerPokemon.TabIndex = 0;
            this.PlayerPokemon.Text = "Player Pokemon";
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlayerHealth.AutoSize = true;
            this.PlayerHealth.Font = new System.Drawing.Font("Stencil", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PlayerHealth.Location = new System.Drawing.Point(263, 205);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(111, 30);
            this.PlayerHealth.TabIndex = 9;
            this.PlayerHealth.Text = "50 / 100";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(608, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // enemyPokemonImage
            // 
            this.enemyPokemonImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enemyPokemonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.enemyPokemonImage.Location = new System.Drawing.Point(1035, 229);
            this.enemyPokemonImage.MaximumSize = new System.Drawing.Size(100, 160);
            this.enemyPokemonImage.MinimumSize = new System.Drawing.Size(100, 160);
            this.enemyPokemonImage.Name = "enemyPokemonImage";
            this.enemyPokemonImage.Size = new System.Drawing.Size(100, 160);
            this.enemyPokemonImage.TabIndex = 11;
            this.enemyPokemonImage.TabStop = false;
            // 
            // playerPokemonImage
            // 
            this.playerPokemonImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerPokemonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerPokemonImage.Location = new System.Drawing.Point(38, 229);
            this.playerPokemonImage.Name = "playerPokemonImage";
            this.playerPokemonImage.Size = new System.Drawing.Size(100, 160);
            this.playerPokemonImage.TabIndex = 10;
            this.playerPokemonImage.TabStop = false;
            // 
            // BattleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1322, 653);
            this.Controls.Add(this.label3);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BattleWindow";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BattleWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).EndInit();
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
        private System.Windows.Forms.Label label3;
    }
}