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
            this.LblBattleText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Comment = new System.Windows.Forms.Label();
            this.LblStats = new System.Windows.Forms.Label();
            this.LblPlayerStatus = new System.Windows.Forms.Label();
            this.LblEnemyStatus = new System.Windows.Forms.Label();
            this.PlayerParty = new System.Windows.Forms.Panel();
            this.LblPlayerPartyTitle = new System.Windows.Forms.Label();
            this.PicBoxPlayerPkmn6 = new System.Windows.Forms.PictureBox();
            this.PicBoxPlayerPkmn5 = new System.Windows.Forms.PictureBox();
            this.PicBoxPlayerPkmn4 = new System.Windows.Forms.PictureBox();
            this.PicBoxPlayerPkmn3 = new System.Windows.Forms.PictureBox();
            this.PicBoxPlayerPkmn2 = new System.Windows.Forms.PictureBox();
            this.PicBoxPlayerPkmn1 = new System.Windows.Forms.PictureBox();
            this.EnemyParty = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PicBoxEnemyPkmn6 = new System.Windows.Forms.PictureBox();
            this.PicBoxEnemyPkmn5 = new System.Windows.Forms.PictureBox();
            this.PicBoxEnemyPkmn4 = new System.Windows.Forms.PictureBox();
            this.PicBoxEnemyPkmn3 = new System.Windows.Forms.PictureBox();
            this.PicBoxEnemyPkmn2 = new System.Windows.Forms.PictureBox();
            this.PicBoxEnemyPkmn1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPokemonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPokemonImage)).BeginInit();
            this.PlayerParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn1)).BeginInit();
            this.EnemyParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn1)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyHealthBar.Location = new System.Drawing.Point(851, 38);
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
            this.playerHealthBar.Location = new System.Drawing.Point(139, 38);
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
            this.Move1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move1.Location = new System.Drawing.Point(139, 497);
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
            this.Move2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move2.Location = new System.Drawing.Point(348, 497);
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
            this.Move3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move3.Location = new System.Drawing.Point(139, 573);
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
            this.Move4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Move4.Location = new System.Drawing.Point(350, 573);
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
            this.enemyPokemonName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.enemyPokemonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.enemyPokemonName.Location = new System.Drawing.Point(846, 3);
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
            this.playerPokemonName.Location = new System.Drawing.Point(134, 9);
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
            this.playerHealthText.Location = new System.Drawing.Point(354, 69);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(717, 11);
            this.label3.MinimumSize = new System.Drawing.Size(40, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // enemyPokemonImage
            // 
            this.enemyPokemonImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyPokemonImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.enemyPokemonImage.Location = new System.Drawing.Point(948, 222);
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
            this.playerPokemonImage.Location = new System.Drawing.Point(156, 222);
            this.playerPokemonImage.MaximumSize = new System.Drawing.Size(309, 369);
            this.playerPokemonImage.MinimumSize = new System.Drawing.Size(209, 269);
            this.playerPokemonImage.Name = "playerPokemonImage";
            this.playerPokemonImage.Size = new System.Drawing.Size(209, 269);
            this.playerPokemonImage.TabIndex = 10;
            this.playerPokemonImage.TabStop = false;
            // 
            // LblBattleText
            // 
            this.LblBattleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBattleText.AutoSize = true;
            this.LblBattleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LblBattleText.Location = new System.Drawing.Point(572, 497);
            this.LblBattleText.MaximumSize = new System.Drawing.Size(500, 0);
            this.LblBattleText.MinimumSize = new System.Drawing.Size(86, 31);
            this.LblBattleText.Name = "LblBattleText";
            this.LblBattleText.Size = new System.Drawing.Size(86, 31);
            this.LblBattleText.TabIndex = 16;
            this.LblBattleText.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(851, 69);
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
            this.Comment.Location = new System.Drawing.Point(996, 143);
            this.Comment.MinimumSize = new System.Drawing.Size(86, 31);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(86, 31);
            this.Comment.TabIndex = 16;
            this.Comment.Text = "label1";
            // 
            // LblStats
            // 
            this.LblStats.AutoSize = true;
            this.LblStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LblStats.Location = new System.Drawing.Point(472, 9);
            this.LblStats.Name = "LblStats";
            this.LblStats.Size = new System.Drawing.Size(40, 18);
            this.LblStats.TabIndex = 18;
            this.LblStats.Text = "stats";
            // 
            // LblPlayerStatus
            // 
            this.LblPlayerStatus.AutoSize = true;
            this.LblPlayerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlayerStatus.Location = new System.Drawing.Point(402, 10);
            this.LblPlayerStatus.Name = "LblPlayerStatus";
            this.LblPlayerStatus.Size = new System.Drawing.Size(64, 25);
            this.LblPlayerStatus.TabIndex = 19;
            this.LblPlayerStatus.Text = "status";
            // 
            // LblEnemyStatus
            // 
            this.LblEnemyStatus.AutoSize = true;
            this.LblEnemyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnemyStatus.Location = new System.Drawing.Point(1114, 7);
            this.LblEnemyStatus.Name = "LblEnemyStatus";
            this.LblEnemyStatus.Size = new System.Drawing.Size(64, 25);
            this.LblEnemyStatus.TabIndex = 20;
            this.LblEnemyStatus.Text = "status";
            // 
            // PlayerParty
            // 
            this.PlayerParty.Controls.Add(this.LblPlayerPartyTitle);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn6);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn5);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn4);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn3);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn2);
            this.PlayerParty.Controls.Add(this.PicBoxPlayerPkmn1);
            this.PlayerParty.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlayerParty.Location = new System.Drawing.Point(0, 0);
            this.PlayerParty.Name = "PlayerParty";
            this.PlayerParty.Size = new System.Drawing.Size(133, 653);
            this.PlayerParty.TabIndex = 21;
            // 
            // LblPlayerPartyTitle
            // 
            this.LblPlayerPartyTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblPlayerPartyTitle.AutoSize = true;
            this.LblPlayerPartyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LblPlayerPartyTitle.Location = new System.Drawing.Point(26, 10);
            this.LblPlayerPartyTitle.Name = "LblPlayerPartyTitle";
            this.LblPlayerPartyTitle.Size = new System.Drawing.Size(72, 29);
            this.LblPlayerPartyTitle.TabIndex = 23;
            this.LblPlayerPartyTitle.Text = "Party";
            // 
            // PicBoxPlayerPkmn6
            // 
            this.PicBoxPlayerPkmn6.Location = new System.Drawing.Point(22, 556);
            this.PicBoxPlayerPkmn6.Name = "PicBoxPlayerPkmn6";
            this.PicBoxPlayerPkmn6.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn6.TabIndex = 5;
            this.PicBoxPlayerPkmn6.TabStop = false;
            this.PicBoxPlayerPkmn6.Click += new System.EventHandler(this.PicBoxPlayerPkmn6_Click);
            // 
            // PicBoxPlayerPkmn5
            // 
            this.PicBoxPlayerPkmn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxPlayerPkmn5.Location = new System.Drawing.Point(22, 454);
            this.PicBoxPlayerPkmn5.Name = "PicBoxPlayerPkmn5";
            this.PicBoxPlayerPkmn5.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn5.TabIndex = 4;
            this.PicBoxPlayerPkmn5.TabStop = false;
            this.PicBoxPlayerPkmn5.Click += new System.EventHandler(this.PicBoxPlayerPkmn5_Click);
            // 
            // PicBoxPlayerPkmn4
            // 
            this.PicBoxPlayerPkmn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxPlayerPkmn4.Location = new System.Drawing.Point(22, 354);
            this.PicBoxPlayerPkmn4.Name = "PicBoxPlayerPkmn4";
            this.PicBoxPlayerPkmn4.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn4.TabIndex = 3;
            this.PicBoxPlayerPkmn4.TabStop = false;
            this.PicBoxPlayerPkmn4.Click += new System.EventHandler(this.PicBoxPlayerPkmn4_Click);
            // 
            // PicBoxPlayerPkmn3
            // 
            this.PicBoxPlayerPkmn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxPlayerPkmn3.Location = new System.Drawing.Point(22, 253);
            this.PicBoxPlayerPkmn3.Name = "PicBoxPlayerPkmn3";
            this.PicBoxPlayerPkmn3.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn3.TabIndex = 2;
            this.PicBoxPlayerPkmn3.TabStop = false;
            this.PicBoxPlayerPkmn3.Click += new System.EventHandler(this.PicBoxPlayerPkmn3_Click);
            // 
            // PicBoxPlayerPkmn2
            // 
            this.PicBoxPlayerPkmn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxPlayerPkmn2.Location = new System.Drawing.Point(22, 151);
            this.PicBoxPlayerPkmn2.Name = "PicBoxPlayerPkmn2";
            this.PicBoxPlayerPkmn2.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn2.TabIndex = 1;
            this.PicBoxPlayerPkmn2.TabStop = false;
            this.PicBoxPlayerPkmn2.Click += new System.EventHandler(this.PicBoxPlayerPkmn2_Click);
            // 
            // PicBoxPlayerPkmn1
            // 
            this.PicBoxPlayerPkmn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxPlayerPkmn1.Location = new System.Drawing.Point(22, 51);
            this.PicBoxPlayerPkmn1.Name = "PicBoxPlayerPkmn1";
            this.PicBoxPlayerPkmn1.Size = new System.Drawing.Size(85, 85);
            this.PicBoxPlayerPkmn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxPlayerPkmn1.TabIndex = 0;
            this.PicBoxPlayerPkmn1.TabStop = false;
            this.PicBoxPlayerPkmn1.Click += new System.EventHandler(this.PicBoxPlayerPkmn1_Click);
            // 
            // EnemyParty
            // 
            this.EnemyParty.Controls.Add(this.label4);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn6);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn5);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn4);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn3);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn2);
            this.EnemyParty.Controls.Add(this.PicBoxEnemyPkmn1);
            this.EnemyParty.Dock = System.Windows.Forms.DockStyle.Right;
            this.EnemyParty.Location = new System.Drawing.Point(1184, 0);
            this.EnemyParty.Name = "EnemyParty";
            this.EnemyParty.Size = new System.Drawing.Size(138, 653);
            this.EnemyParty.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(31, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 29);
            this.label4.TabIndex = 30;
            this.label4.Text = "Party";
            // 
            // PicBoxEnemyPkmn6
            // 
            this.PicBoxEnemyPkmn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn6.Location = new System.Drawing.Point(27, 557);
            this.PicBoxEnemyPkmn6.Name = "PicBoxEnemyPkmn6";
            this.PicBoxEnemyPkmn6.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn6.TabIndex = 29;
            this.PicBoxEnemyPkmn6.TabStop = false;
            // 
            // PicBoxEnemyPkmn5
            // 
            this.PicBoxEnemyPkmn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn5.Location = new System.Drawing.Point(27, 455);
            this.PicBoxEnemyPkmn5.Name = "PicBoxEnemyPkmn5";
            this.PicBoxEnemyPkmn5.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn5.TabIndex = 28;
            this.PicBoxEnemyPkmn5.TabStop = false;
            // 
            // PicBoxEnemyPkmn4
            // 
            this.PicBoxEnemyPkmn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn4.Location = new System.Drawing.Point(27, 355);
            this.PicBoxEnemyPkmn4.Name = "PicBoxEnemyPkmn4";
            this.PicBoxEnemyPkmn4.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn4.TabIndex = 27;
            this.PicBoxEnemyPkmn4.TabStop = false;
            // 
            // PicBoxEnemyPkmn3
            // 
            this.PicBoxEnemyPkmn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn3.Location = new System.Drawing.Point(27, 254);
            this.PicBoxEnemyPkmn3.Name = "PicBoxEnemyPkmn3";
            this.PicBoxEnemyPkmn3.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn3.TabIndex = 26;
            this.PicBoxEnemyPkmn3.TabStop = false;
            // 
            // PicBoxEnemyPkmn2
            // 
            this.PicBoxEnemyPkmn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn2.Location = new System.Drawing.Point(27, 152);
            this.PicBoxEnemyPkmn2.Name = "PicBoxEnemyPkmn2";
            this.PicBoxEnemyPkmn2.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn2.TabIndex = 25;
            this.PicBoxEnemyPkmn2.TabStop = false;
            // 
            // PicBoxEnemyPkmn1
            // 
            this.PicBoxEnemyPkmn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBoxEnemyPkmn1.Location = new System.Drawing.Point(27, 52);
            this.PicBoxEnemyPkmn1.Name = "PicBoxEnemyPkmn1";
            this.PicBoxEnemyPkmn1.Size = new System.Drawing.Size(85, 85);
            this.PicBoxEnemyPkmn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxEnemyPkmn1.TabIndex = 24;
            this.PicBoxEnemyPkmn1.TabStop = false;
            // 
            // BattleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1322, 653);
            this.Controls.Add(this.EnemyParty);
            this.Controls.Add(this.PlayerParty);
            this.Controls.Add(this.LblEnemyStatus);
            this.Controls.Add(this.LblPlayerStatus);
            this.Controls.Add(this.LblStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.LblBattleText);
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
            this.PlayerParty.ResumeLayout(false);
            this.PlayerParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxPlayerPkmn1)).EndInit();
            this.EnemyParty.ResumeLayout(false);
            this.EnemyParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxEnemyPkmn1)).EndInit();
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
        private System.Windows.Forms.Label LblBattleText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Comment;
        private System.Windows.Forms.Label LblStats;
        private System.Windows.Forms.Label LblPlayerStatus;
        private System.Windows.Forms.Label LblEnemyStatus;
        private System.Windows.Forms.Panel PlayerParty;
        private System.Windows.Forms.Panel EnemyParty;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn6;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn5;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn4;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn3;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn2;
        private System.Windows.Forms.PictureBox PicBoxPlayerPkmn1;
        private System.Windows.Forms.Label LblPlayerPartyTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn6;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn5;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn4;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn3;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn2;
        private System.Windows.Forms.PictureBox PicBoxEnemyPkmn1;
    }
}