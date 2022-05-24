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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleWindow));
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.Move1 = new System.Windows.Forms.Button();
            this.Move2 = new System.Windows.Forms.Button();
            this.Move3 = new System.Windows.Forms.Button();
            this.Move4 = new System.Windows.Forms.Button();
            this.enemyPokemonName = new System.Windows.Forms.Label();
            this.playerPokemonName = new System.Windows.Forms.Label();
            this.playerHealthText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.enemyPokemonImage = new System.Windows.Forms.PictureBox();
            this.playerPokemonImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Comment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyHealthBar.Location = new System.Drawing.Point(818, 40);
            this.enemyHealthBar.MaximumSize = new System.Drawing.Size(327, 28);
            this.enemyHealthBar.MinimumSize = new System.Drawing.Size(327, 28);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(327, 28);
            this.enemyHealthBar.TabIndex = 1;
            this.enemyHealthBar.Value = 100;
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerHealthBar.Location = new System.Drawing.Point(38, 40);
            this.playerHealthBar.MaximumSize = new System.Drawing.Size(327, 28);
            this.playerHealthBar.MinimumSize = new System.Drawing.Size(327, 28);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(327, 28);
            this.playerHealthBar.TabIndex = 2;
            this.playerHealthBar.Value = 50;
            // 
            // Move1
            // 
            this.Move1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Move1.BackColor = System.Drawing.SystemColors.Control;
            this.Move1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move1.Location = new System.Drawing.Point(7, 374);
            this.Move1.MaximumSize = new System.Drawing.Size(203, 70);
            this.Move1.MinimumSize = new System.Drawing.Size(203, 70);
            this.Move1.Name = "Move1";
            this.Move1.Size = new System.Drawing.Size(203, 70);
            this.Move1.TabIndex = 1;
            this.Move1.Text = "Move1";
            this.Move1.UseVisualStyleBackColor = false;
            this.Move1.Click += new System.EventHandler(this.Move1_Click);
            // 
            // Move2
            // 
            this.Move2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Move2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move2.Location = new System.Drawing.Point(216, 374);
            this.Move2.MaximumSize = new System.Drawing.Size(203, 70);
            this.Move2.MinimumSize = new System.Drawing.Size(203, 70);
            this.Move2.Name = "Move2";
            this.Move2.Size = new System.Drawing.Size(203, 70);
            this.Move2.TabIndex = 2;
            this.Move2.Text = "Move2";
            this.Move2.UseVisualStyleBackColor = true;
            this.Move2.Click += new System.EventHandler(this.Move2_Click);
            // 
            // Move3
            // 
            this.Move3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Move3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move3.Location = new System.Drawing.Point(7, 450);
            this.Move3.MaximumSize = new System.Drawing.Size(203, 70);
            this.Move3.MinimumSize = new System.Drawing.Size(203, 70);
            this.Move3.Name = "Move3";
            this.Move3.Size = new System.Drawing.Size(203, 70);
            this.Move3.TabIndex = 3;
            this.Move3.Text = "Move3";
            this.Move3.UseVisualStyleBackColor = true;
            this.Move3.Click += new System.EventHandler(this.Move3_Click);
            // 
            // Move4
            // 
            this.Move4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Move4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move4.Location = new System.Drawing.Point(218, 450);
            this.Move4.MaximumSize = new System.Drawing.Size(203, 70);
            this.Move4.MinimumSize = new System.Drawing.Size(203, 70);
            this.Move4.Name = "Move4";
            this.Move4.Size = new System.Drawing.Size(203, 70);
            this.Move4.TabIndex = 4;
            this.Move4.Text = "Move4";
            this.Move4.UseVisualStyleBackColor = true;
            this.Move4.Click += new System.EventHandler(this.Move4_Click);
            // 
            // enemyPokemonName
            // 
            this.enemyPokemonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyPokemonName.AutoSize = true;
            this.enemyPokemonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.enemyPokemonName.Location = new System.Drawing.Point(813, 11);
            this.enemyPokemonName.MaximumSize = new System.Drawing.Size(321, 129);
            this.enemyPokemonName.MinimumSize = new System.Drawing.Size(221, 29);
            this.enemyPokemonName.Name = "enemyPokemonName";
            this.enemyPokemonName.Size = new System.Drawing.Size(221, 29);
            this.enemyPokemonName.TabIndex = 0;
            this.enemyPokemonName.Text = "Enemy Pokemon";
            // 
            // playerPokemonName
            // 
            this.playerPokemonName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerPokemonName.AutoSize = true;
            this.playerPokemonName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerPokemonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.playerPokemonName.Location = new System.Drawing.Point(33, 11);
            this.playerPokemonName.MaximumSize = new System.Drawing.Size(314, 129);
            this.playerPokemonName.MinimumSize = new System.Drawing.Size(214, 29);
            this.playerPokemonName.Name = "playerPokemonName";
            this.playerPokemonName.Size = new System.Drawing.Size(214, 29);
            this.playerPokemonName.TabIndex = 0;
            this.playerPokemonName.Text = "Player Pokemon";
            // 
            // playerHealthText
            // 
            this.playerHealthText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerHealthText.AutoSize = true;
            this.playerHealthText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.playerHealthText.Location = new System.Drawing.Point(263, 71);
            this.playerHealthText.MaximumSize = new System.Drawing.Size(212, 129);
            this.playerHealthText.MinimumSize = new System.Drawing.Size(112, 29);
            this.playerHealthText.Name = "playerHealthText";
            this.playerHealthText.Size = new System.Drawing.Size(112, 29);
            this.playerHealthText.TabIndex = 9;
            this.playerHealthText.Text = "50 / 100";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(666, 535);
            this.label3.MinimumSize = new System.Drawing.Size(86, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // enemyPokemonImage
            // 
            this.enemyPokemonImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyPokemonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.enemyPokemonImage.Location = new System.Drawing.Point(1035, 99);
            this.enemyPokemonImage.MaximumSize = new System.Drawing.Size(309, 369);
            this.enemyPokemonImage.MinimumSize = new System.Drawing.Size(209, 269);
            this.enemyPokemonImage.Name = "enemyPokemonImage";
            this.enemyPokemonImage.Size = new System.Drawing.Size(209, 269);
            this.enemyPokemonImage.TabIndex = 11;
            this.enemyPokemonImage.TabStop = false;
            // 
            // playerPokemonImage
            // 
            this.playerPokemonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerPokemonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerPokemonImage.Location = new System.Drawing.Point(38, 99);
            this.playerPokemonImage.MaximumSize = new System.Drawing.Size(309, 369);
            this.playerPokemonImage.MinimumSize = new System.Drawing.Size(209, 269);
            this.playerPokemonImage.Name = "playerPokemonImage";
            this.playerPokemonImage.Size = new System.Drawing.Size(209, 269);
            this.playerPokemonImage.TabIndex = 10;
            this.playerPokemonImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(654, 489);
            this.label1.MinimumSize = new System.Drawing.Size(86, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(813, 71);
            this.label2.MaximumSize = new System.Drawing.Size(212, 129);
            this.label2.MinimumSize = new System.Drawing.Size(112, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "50 / 100";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Comment
            // 
            this.Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comment.AutoSize = true;
            this.Comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Comment.Location = new System.Drawing.Point(883, 138);
            this.Comment.MinimumSize = new System.Drawing.Size(86, 31);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(86, 31);
            this.Comment.TabIndex = 16;
            this.Comment.Text = "label1";
            // 
            // BattleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1322, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enemyPokemonImage);
            this.Controls.Add(this.playerPokemonImage);
            this.Controls.Add(this.playerHealthText);
            this.Controls.Add(this.playerPokemonName);
            this.Controls.Add(this.enemyPokemonName);
            this.Controls.Add(this.Move4);
            this.Controls.Add(this.Move3);
            this.Controls.Add(this.Move2);
            this.Controls.Add(this.Move1);
            this.Controls.Add(this.playerHealthBar);
            this.Controls.Add(this.enemyHealthBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(1340, 700);
            this.Name = "BattleWindow";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.BattleWindow_Load);
            this.ResizeEnd += new System.EventHandler(this.ResizeScreen);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseCoord);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.Button Move1;
        private System.Windows.Forms.Button Move2;
        private System.Windows.Forms.Button Move4;
        private System.Windows.Forms.Button Move3;
        private System.Windows.Forms.Label enemyPokemonName;
        private System.Windows.Forms.Label playerPokemonName;
        private System.Windows.Forms.Label playerHealthText;
        private System.Windows.Forms.PictureBox playerPokemonImage;
        private System.Windows.Forms.PictureBox enemyPokemonImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Comment;
    }
}