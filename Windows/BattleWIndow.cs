﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace Pokemon_Simulator.Properties
{
    public partial class BattleWindow : Form
    {

        public static BattleWindow instance;

        ComponentResourceManager resources = new ComponentResourceManager(typeof(BattleWindow));

        public GameState state;

        public Pokemon activePokemon { get; private set; }
        int activePokemonIndex;
        public Pokemon activeEnemyPokemon { get; private set; }
        int activeEnemyPokemonIndex;
        int selectedMove;
        Move enemySelectedMove;

        Label lblMCX = new Label();
        Label lblMCY = new Label();
        List<Move> moves = new List<Move>();

        int secs = 0;
        bool playerFirst;
        bool requireSwitchIn;
        bool coolDown;
        bool EcoolDown;

        Random rand = new Random();

        Image originalBackGroundPic;

        // If 1, the player was skipped. If 2, the enemy was skipped. If 0, no one was skipped
        int skippedTurn = 0;

        public BattleWindow()
        {
            InitializeComponent();

            // Initialize an instance to this class so other classes can access certain parts
            if(instance == null)
            {
                instance = this;
            }
        }

        //Am assuming this where battle begins, so add buttons and such, might as well say that u can experiment
        private void BattleWindow_Load(object sender, EventArgs e)
        {
            originalBackGroundPic = BackgroundImage;

            LoadEnemyPokemonIntoBattle(0);
            LoadPlayerPokemonIntoBattle(0);

            lblMCY.Show();
            lblMCY.Location = new Point(500, 50);

            lblMCX.Show();
            lblMCX.Location = new Point(500, 20);
            //TODO: Event for Image Resizing.(Scaling) Item re-placeement depenign on the screen size.

            LoadPartyPictures();

            LblPlayerStatus.Hide();
            LblEnemyStatus.Hide();
            Comment.Hide();
        }

        private void LoadPlayerPokemonIntoBattle(int pokemonIndex)
        {
            Pokemon pokemon = BattleData.pokemonList[pokemonIndex];
            activePokemonIndex = pokemonIndex;
            activePokemon = pokemon;
            moves = pokemon.moves;

            playerPokemonName.Text = pokemon.displayName;
            playerPokemonName.ForeColor = activePokemon.MainColor;
            playerHealthBar.Maximum = (int)pokemon.GetHealth();
            playerHealthBar.Value = (int)pokemon.currHealth;
            playerHealthText.Text = activePokemon.currHealth + "/" + activePokemon.GetHealth();

            playerPokemonImage.SizeMode = PictureBoxSizeMode.Zoom;
            // Get the directory of the actual project, then get the resources folder
            playerPokemonImage.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + @"\Pokemon-Simulator\Resources\" + pokemon.name + "_Battle.png");
            playerPokemonImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Load their moves too
            LoadPlayerMoves(moves);

            // Now the enemy knows this pokemon 
            activeEnemyPokemon.knownPokemons.Add(pokemon);
            activeEnemyPokemon.SetRivalPokemon(pokemon);

            BattleEventHandler.instance.OnPokemonSwitchIn(pokemon);

        }

        private void LoadPlayerMoves(List<Move> moves)
        {
            // If they have less than 4 moves, make sure we are not trying to access elements that don't exist
            if (moves.Count >= 1)
            {
                Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
                Move1.BackColor = TypeData.GetTypeColor(moves[0].type);
            }
            if (moves.Count >= 2)
            {
                Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
                Move2.BackColor = TypeData.GetTypeColor(moves[1].type);
            }
            if (moves.Count >= 3)
            {
                Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
                Move3.BackColor = TypeData.GetTypeColor(moves[2].type);
            }
            if (moves.Count >= 4)
            {
                Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
                Move4.BackColor = TypeData.GetTypeColor(moves[3].type);
            }

            Move1.Enabled = Move2.Enabled = Move3.Enabled = Move4.Enabled = true;
        }

        private void LoadEnemyPokemonIntoBattle(int pokemonIndex)
        {
            Pokemon pokemon = BattleData.enemyList[pokemonIndex];
            activeEnemyPokemonIndex = pokemonIndex;
            activeEnemyPokemon = pokemon;

            enemyPokemonName.Text = pokemon.displayName;
            enemyHealthBar.Maximum = (int)pokemon.GetHealth();
            enemyHealthBar.Value = (int)pokemon.currHealth;
            label2.Text = pokemon.currHealth + "/" + pokemon.GetHealth();

            enemyPokemonImage.SizeMode = PictureBoxSizeMode.Zoom;
            // Get the directory of the actual project, then get the resources folder
            enemyPokemonImage.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + @"\Pokemon-Simulator\Resources\" + pokemon.name + "_Battle.png");

            BattleEventHandler.instance.OnPokemonSwitchIn(activeEnemyPokemon);
        }

        private void Move1_Click(object sender, EventArgs e)
        {
            if (moves[0].pp > 0 && !coolDown)
            {
                Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
                selectedMove = 0;                
                
                // See if the current pokemon is holding a "choice" item
                if(activePokemon.item != null) Move2.Enabled = Move3.Enabled = Move4.Enabled = !activePokemon.item.itemName.Contains("Choice");
            }

            // No more moves? Struggle.
            if (NoMoreMoves(activePokemon))
            {
                selectedMove = -1;
            }

            StartTurn();
        }

        private void Move2_Click(object sender, EventArgs e)
        {
            if (moves[1].pp > 0 && !coolDown)
            {
                Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
                selectedMove = 1;

                if (activePokemon.item != null) Move1.Enabled = Move3.Enabled = Move4.Enabled = !activePokemon.item.itemName.Contains("Choice");
            }

            if (NoMoreMoves(activePokemon))
            {
                selectedMove = -1;
            }

            StartTurn();
        }

        private void Move3_Click(object sender, EventArgs e)
        {
            if (moves[2].pp > 0 && !coolDown)
            {
                Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
                selectedMove = 2;

                if (activePokemon.item != null) Move1.Enabled = Move2.Enabled = Move4.Enabled = !activePokemon.item.itemName.Contains("Choice");
            }

            if (NoMoreMoves(activePokemon))
            {
                selectedMove = -1;
            }

            StartTurn();
        }

        private void Move4_Click(object sender, EventArgs e)
        {
            if (moves[3].pp > 0 && !coolDown)
            {
                Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
                selectedMove = 3;

                if (activePokemon.item != null) Move1.Enabled = Move2.Enabled = Move3.Enabled = !activePokemon.item.itemName.Contains("Choice");
            }

            if (NoMoreMoves(activePokemon))
            {
                selectedMove = -1;
            }

            StartTurn();
        }

        private void StartTurn()
        {
            BattleData.turnCounter++; // We are in the "next" turn
            skippedTurn = 0;

            enemySelectedMove = activeEnemyPokemon.AICPU(playerFirst);

            // Speed calculations
            playerFirst = activePokemon.currSpeed >= activeEnemyPokemon.currSpeed;
            if (BattleData.HasSubWeather(ref BattleData.playerSubWeather, "Trick Room") != null || BattleData.HasSubWeather(ref BattleData.enemySubWeather, "Trick Room") != null)
            {
                playerFirst = activePokemon.currSpeed <= activeEnemyPokemon.currSpeed;
            }
            if(selectedMove >= 0)
            {
                if (enemySelectedMove.priority > moves[selectedMove].priority) playerFirst = false;
                else if (enemySelectedMove.priority < moves[selectedMove].priority) playerFirst = true;
                if (enemySelectedMove.actualAttack && moves[selectedMove].moveName == "Sucker Punch")
                {
                    playerFirst = true;
                }
            }

            Commentary_Battle();
            timer1.Start();
            coolDown = true;

            Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
            Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
            Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
            Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
        }

        private void PlayerTurn()
        {            
            if (selectedMove == -2) return;
            if (CheckStatus(activePokemon)) return;
            if (skippedTurn == 1)
            {
                LblBattleText.Text = activePokemon.displayName + " was flinched!";
                return;
            }

            int damage = 0;
            if (selectedMove != -1)
            {
                // Damage the enemy
                damage = activePokemon.UseMove(moves[selectedMove], activeEnemyPokemon);
                LblBattleText.Text = activePokemon.name + " used " + moves[selectedMove].moveName;
                if (damage >= 0) { LblBattleText.Text += " dealing " + damage + " damage!"; }
                else { LblBattleText.Text += "!"; }

                activeEnemyPokemon.knownMoves.Add(activePokemon.moves[selectedMove]);
            }
            else
            {
                damage = activePokemon.UseMove(new Struggle(activePokemon), activeEnemyPokemon);
                LblBattleText.Text = activePokemon.name + " used Struggle dealing " + damage + " damage!";
            }

            UpdateHealthBar(0);
            UpdateHealthBar(1);

            //if the player used a move that changed their stats, display it here
            UpdateStatLabel();

        }

        private void Commentary_Battle()
        {
            Comment.Show();
            Comment.Location = new Point(enemyPokemonImage.Location.X - 100, enemyPokemonImage.Location.Y);

            if (activeEnemyPokemon.currHealth < activeEnemyPokemon.GetHealth() * 20 / 100 && activeEnemyPokemon.currHealth > 0 && (rand.Next(0, 5) == 1))
            {
                Comment.Text = activeEnemyPokemon.GetOnHitComment()[4];
            }
            else if (activeEnemyPokemon.currHealth <= 0)
            {
                Comment.Text = activeEnemyPokemon.GetOnHitComment()[4];
            }
            else
            {
                Comment.Text = activeEnemyPokemon.GetOnHitComment()[rand.Next(0, 4)];
            }
            //if (selectedMove >= 0 && activePokemon.GetDamage(moves[selectedMove], activeEnemyPokemon) < activeEnemyPokemon.GetHealth() * 20 / 100)
            //{
            //    Comment.Text = activeEnemyPokemon.GetComment()[4];
            //}
        }

        private void EnemyTurn()
        {
            if (!EcoolDown)
            {
                // Now that selectedMove is global, we can put this here
                if (CheckStatus(activeEnemyPokemon)) return;

                if (skippedTurn == 2)
                {
                    LblBattleText.Text = activeEnemyPokemon.displayName + " was flinched!";
                    return;
                }

                //AttackAnimation(playerPokemonImage, -1);h
                if (!NoMoreMoves(activeEnemyPokemon))
                {
                    // Damage the player                   
                    //activeEnemyPokemon.AICPU(playerFirst);
                    int damage = activeEnemyPokemon.UseMove(enemySelectedMove, activePokemon);
                    LblBattleText.Text = activeEnemyPokemon.name + " used " + activeEnemyPokemon.lastUsedMove.moveName;
                    if (damage > 0) { LblBattleText.Text += " dealing " + damage + " damage!"; }
                    else { LblBattleText.Text += "!"; }
                }
                else
                {
                    int damage = activeEnemyPokemon.UseMove(new Struggle(activePokemon), activeEnemyPokemon);
                    LblBattleText.Text = activeEnemyPokemon.name + " used Struggle dealing " + damage + " damage!";
                }
            }
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            EcoolDown = true;

            //if the enemy used a move that changed their stats, display it here
            UpdateStatLabel();
        }

        private void EndTurn()
        {
            // This code can go either in the timer method, this method, or its own method.
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            LblBattleText.Hide();

            // Update the move counter at the end incase it doesnt update earlier
            Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
            Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
            Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
            Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
        }

        private void PlayerAttackAnimation(Object source, ElapsedEventArgs e)
        {

        }

        private void HurtAnimation(PictureBox picture)
        {

        }

        void ResizeScreen(Object source, EventArgs e)
        {
            //enemyHealthBar.Location = new Point(this.Location.X+700, this.Location.Y+20);

        }
        void MouseCoord(Object source, MouseEventArgs e)
        {
            //label3.Text= "Xpos: "+e.X.ToString() + "Ypos: "+e.Y.ToString();

            lblMCY.Text = e.Y.ToString();


        }

        /// <summary>
        /// Updates the current GameState so the window knows which state of the battle we are on
        /// </summary>
        public void UpdateGameState(GameState newState)
        {
            // We have the current GameState as a public variable here, so we update it to the newState
            state = newState;

            // Trigger the event so any class listening to this event knows the state has changed
            BattleEventHandler.instance.OnGameStateChange(newState);

            // Depending on the newState, we can do some code here
            switch (newState)
            {
                case GameState.PlayerSelectMove:
                    break;

                case GameState.StartPlayerTurn:
                    PlayerTurn();
                    break;

                case GameState.EndPlayerTurn:
                    CheckFainted();
                    break;

                case GameState.StartEnemyTurn:
                    Comment.Hide();
                    EcoolDown = false;
                    EnemyTurn();
                    break;

                case GameState.EndEnemyTurn:
                    CheckFainted();
                    break;

                case GameState.EndTurn:
                    EndTurn();
                    break;

            }     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secs++;
            //Console.WriteLine(secs);
            if (secs == 10)
            {
                LblBattleText.Text = "";
                LblBattleText.Show();

                if (playerFirst) UpdateGameState(GameState.StartPlayerTurn);
                else UpdateGameState(GameState.StartEnemyTurn);
            }
            else if (secs == 50)
            {
                if (playerFirst) UpdateGameState(GameState.EndPlayerTurn);
                else UpdateGameState(GameState.EndEnemyTurn);
            }
            else if (secs == 100)
            {
                if (playerFirst) UpdateGameState(GameState.StartEnemyTurn);
                else UpdateGameState(GameState.StartPlayerTurn);
            }
            else if (secs == 150)
            {
                if (playerFirst) UpdateGameState(GameState.EndEnemyTurn);
                else UpdateGameState(GameState.EndPlayerTurn);
            }

            if (secs == 200)
            {
                UpdateGameState(GameState.EndTurn);
            }

            if(secs > 200)
            {
                if(!requireSwitchIn)
                {
                    coolDown = false;
                    secs = 0;
                    UpdateGameState(GameState.PlayerSelectMove);
                    timer1.Stop();
                }
                else
                {
                    LblBattleText.Text = "Select a new Pokemon...";
                }
            }

        }

        #region Updating the window

        /// <summary>
        /// Updates the health bar in the window.
        /// 0 for the player's, 1 for the enemy's
        /// </summary>
        private void UpdateHealthBar(int mode)
        {
            if (mode == 0)
            {
                if (activePokemon.currHealth > 0)
                {
                    playerHealthBar.Value = (int)activePokemon.currHealth;
                    playerHealthText.Text = (int)activePokemon.currHealth + "/" + activePokemon.GetHealth();
                }
                else
                {
                    playerHealthBar.Value = 0;
                    playerHealthText.Text = "0/" + activePokemon.GetHealth();
                }

                if(activePokemon.currentStatusEffect != null)
                {
                    LblPlayerStatus.Show();
                    LblPlayerStatus.Text = activePokemon.currentStatusEffect.statusName;
                    LblPlayerStatus.BackColor = activePokemon.currentStatusEffect.GetColor();
                }
                else
                {
                    LblPlayerStatus.Hide();
                }
            }
            else
            {
                if (activeEnemyPokemon.currHealth > 0)
                {
                    enemyHealthBar.Value = (int)activeEnemyPokemon.currHealth;
                    label2.Text = (int)activeEnemyPokemon.currHealth + "/" + activeEnemyPokemon.GetHealth();
                }
                else
                {
                    enemyHealthBar.Value = 0;
                    label2.Text = "0/" + activeEnemyPokemon.GetHealth();
                }

                if(activeEnemyPokemon.currentStatusEffect != null)
                {
                    LblEnemyStatus.Show();
                    LblEnemyStatus.Text = activeEnemyPokemon.currentStatusEffect.statusName;
                    LblEnemyStatus.BackColor = activeEnemyPokemon.currentStatusEffect.GetColor();
                }
                else
                {
                    LblEnemyStatus.Hide();
                }
            }
        }

        /// <summary>
        /// Update the label that holds player and enemy
        /// stat changes
        /// </summary>
        private void UpdateStatLabel()
        {
            string playerStats = "";
            if (activePokemon.attackStage != 0) playerStats += "Attack: " + NumToPercentStatConvert(activePokemon.attackStage) + "\n";
            if (activePokemon.defenseStage != 0) playerStats += "Defense: " + NumToPercentStatConvert(activePokemon.defenseStage) + "\n";
            if (activePokemon.specialAttackStage != 0) playerStats += "Special Attack: " + NumToPercentStatConvert(activePokemon.specialAttackStage) + "\n";
            if (activePokemon.specialDefenseStage != 0) playerStats += "Special Defense: " + NumToPercentStatConvert(activePokemon.specialDefenseStage) + "\n";
            if (activePokemon.speedStage != 0) playerStats += "Speed: " + NumToPercentStatConvert(activePokemon.speedStage);
            LblStats.Text = playerStats;

            string enemyStats = "";
            if (activeEnemyPokemon.attackStage != 0) enemyStats += "Attack: " + NumToPercentStatConvert(activeEnemyPokemon.attackStage) + "\n";
            if (activeEnemyPokemon.defenseStage != 0) enemyStats += "Defense: " + NumToPercentStatConvert(activeEnemyPokemon.defenseStage) + "\n";
            if (activeEnemyPokemon.specialAttackStage != 0) enemyStats += "Special Attack: " + NumToPercentStatConvert(activeEnemyPokemon.specialAttackStage) + "\n";
            if (activeEnemyPokemon.specialDefenseStage != 0) enemyStats += "Special Defense: " + NumToPercentStatConvert(activeEnemyPokemon.specialDefenseStage) + "\n";
            if (activeEnemyPokemon.speedStage != 0) enemyStats += "Speed: " + NumToPercentStatConvert(activeEnemyPokemon.speedStage);
            label3.Text = enemyStats;
        }

        /// <summary>
        /// Converts a stat change into a string representation of how much the stat has changed.
        /// </summary>
        private string NumToPercentStatConvert(int statStage, bool accuracyOrEvasion=false)
        {
            if(accuracyOrEvasion)
            {
                if (statStage == 1) return "1.33x";
                if (statStage == 2) return "1.66x";
                if (statStage == 3) return "2x";
                if (statStage == 4) return "2.33x";
                if (statStage == 5) return "2.66x";
                if (statStage == 6) return "3x";

                if (statStage == -1) return "0.75x";
                if (statStage == -2) return "0.60x";
                if (statStage == -3) return "0.50x";
                if (statStage == -4) return "0.428x";
                if (statStage == -5) return "0.375x";
                if (statStage == -6) return "0.33x";
            }
            else
            {
                if (statStage == 1) return "1.5x";
                if (statStage == 2) return "2x";
                if (statStage == 3) return "2.5x";
                if (statStage == 4) return "3x";
                if (statStage == 5) return "3.5x";
                if (statStage == 6) return "4x";
 
                if (statStage == -1) return "0.66x";
                if (statStage == -2) return "0.50x";
                if (statStage == -3) return "0.40x";
                if (statStage == -4) return "0.33x";
                if (statStage == -5) return "0.285x";
                if (statStage == -6) return "0.25x";
            }
            return "";
        }

        // From: https://stackoverflow.com/questions/33024881/invert-image-faster-in-c-sharp
        public void InvertBackgroundColor()
        {
            Bitmap pic = new Bitmap(BackgroundImage);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            BackgroundImage = pic;
        }

        public void TintBackgroundColor(float redTint, float greenTint, float blueTint)
        {
            redTint /= 255;
            greenTint /= 255;
            blueTint /= 255;

            Bitmap pic = new Bitmap(BackgroundImage);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    int red = (int) (inv.R + (255 - inv.R) * redTint);
                    int green = (int) (inv.G + (255 - inv.G) * greenTint);
                    int blue = (int) (inv.B + (255 - inv.B) * blueTint);

                    if (red > 255) red = 255;
                    if (green > 255) green = 255;
                    if (blue > 255) blue = 255;

                    inv = Color.FromArgb(255, red , green, blue);
                    pic.SetPixel(x, y, inv);
                }
            }
            BackgroundImage = pic;
        }

        public void ResetBackground()
        {
            BackgroundImage = originalBackGroundPic;
        }

        #endregion

        #region Checking Status of Battle

        private bool NoMoreMoves(Pokemon pkmn)
        {
            return pkmn.moves[0].pp == 0 && pkmn.moves[1].pp == 0 && pkmn.moves[2].pp == 0 && pkmn.moves[3].pp == 0;
        }

        private int CheckFainted()
        {
            // if one of the pokemon has lost all of their HP, raise the event so other classes know a pokemon has fainted
            if(activePokemon.currHealth <= 0)
            {
                GrayOutPartyPicture(0, activePokemonIndex);
                LblBattleText.Text = activePokemon.displayName + " has fainted!";
                BattleEventHandler.instance.OnPlayerPokemonFainted(activePokemon);
                secs = 151;
                requireSwitchIn = true;
                return 0; // 0 for the player
            }

            if(activeEnemyPokemon.currHealth <= 0)
            {
                GrayOutPartyPicture(1, activeEnemyPokemonIndex);
                LblBattleText.Text = activeEnemyPokemon.displayName + " has fainted!";
                BattleEventHandler.instance.OnPlayerPokemonFainted(activeEnemyPokemon);
                secs = 151;

                // TODO: idk probs some method that lets the CPU switch out their pokemon

                return 1; // 1 for the enemy
            }
            return -1; // no one has fainted yet
        }

        private bool CheckStatus(Pokemon pokemon)
        {
            if(pokemon.currentStatusEffect != null)
            {
                StatusEffect statusEffect = pokemon.currentStatusEffect;
                if(statusEffect.Effect())
                {
                    if (statusEffect.statusName == "Frozen")
                    {
                        LblBattleText.Text = pokemon.displayName + " is frozen!";
                    }
                    else if (statusEffect.statusName == "Asleep")
                    {
                        LblBattleText.Text = pokemon.displayName + " is asleep!";
                    }
                    else if (statusEffect.statusName == "Paralysis")
                    {
                        LblBattleText.Text = pokemon.displayName + " is paralyzed!";
                    }
                    return true;
                }
                else
                {
                    if (statusEffect.statusName == "Frozen")
                    {
                        LblBattleText.Text = pokemon.displayName + " thawed out!";
                    }
                    else if (statusEffect.statusName == "Asleep")
                    {
                        LblBattleText.Text = pokemon.displayName + " woke up!";
                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Skips the pokemon's turn
        /// </summary>
        public void SkipTurn(string reason="")
        {
            // TODO: might skip turn for other reasons besides flinching
            if (secs > 100) return;
            skippedTurn = playerFirst ? 2 : 1; // If player first, set skippedTurn to 2, else, 1
        }

        #region Enabling or Disabling Moves

        /// <summary>
        /// Disables a specific move (or moves if you specify more than one)
        /// </summary>
        public void DisableMove(params string[] moves)
        {
            if (moves.Length > 4) return;
            foreach(string moveName in moves)
            {
                if (Move1.Text.Contains(moveName)) Move1.Enabled = false;
                else if (Move2.Text.Contains(moveName)) Move2.Enabled = false;
                else if (Move3.Text.Contains(moveName)) Move3.Enabled = false;
                else if (Move4.Text.Contains(moveName)) Move4.Enabled = false;
            }
        }

        /// <summary>
        /// Disables all the moves except the one specified in the parameter.
        /// </summary>
        public void DisableAllButOneMove(string moveName)
        {
            if (!Move1.Text.Contains(moveName)) Move1.Enabled = false;
            if (!Move2.Text.Contains(moveName)) Move2.Enabled = false;
            if (!Move3.Text.Contains(moveName)) Move3.Enabled = false;
            if (!Move4.Text.Contains(moveName)) Move4.Enabled = false;
        }

        /// <summary>
        /// Enables a specific move.
        /// </summary>
        public void EnableMove(string moveName)
        {
            if (Move1.Text.Contains(moveName)) Move1.Enabled = true;
            if (Move2.Text.Contains(moveName)) Move2.Enabled = true;
            if (Move3.Text.Contains(moveName)) Move3.Enabled = true;
            if (Move4.Text.Contains(moveName)) Move4.Enabled = true;
        }

        /// <summary>
        /// Enables all moves if they were disabled.
        /// </summary>
        public void EnableAllMoves()
        {
            Move1.Enabled = Move2.Enabled = Move3.Enabled = Move4.Enabled = true;
        }

        #endregion

        #region Party Picture Methods

        private void LoadPartyPictures()
        {
            int playerPartySize = BattleData.pokemonList.Count;           
            if(playerPartySize >= 1) PicBoxPlayerPkmn1.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[0].name + "_Pfp.png");
            if (playerPartySize >= 2) PicBoxPlayerPkmn2.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[1].name + "_Pfp.png");
            if (playerPartySize >= 3) PicBoxPlayerPkmn3.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[2].name + "_Pfp.png");
            if (playerPartySize >= 4) PicBoxPlayerPkmn4.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[3].name + "_Pfp.png");
            if (playerPartySize >= 5) PicBoxPlayerPkmn5.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[4].name + "_Pfp.png");
            if (playerPartySize >= 6) PicBoxPlayerPkmn6.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.pokemonList[5].name + "_Pfp.png");

            int enemyPartySize = BattleData.enemyList.Count;
            if (enemyPartySize >= 1) PicBoxEnemyPkmn1.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[0].name + "_Pfp.png");
            if (enemyPartySize >= 2) PicBoxEnemyPkmn2.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[1].name + "_Pfp.png");
            if (enemyPartySize >= 3) PicBoxEnemyPkmn3.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[2].name + "_Pfp.png");
            if (enemyPartySize >= 4) PicBoxEnemyPkmn4.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[3].name + "_Pfp.png");
            if (enemyPartySize >= 5) PicBoxEnemyPkmn5.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[4].name + "_Pfp.png");
            if (enemyPartySize >= 6) PicBoxEnemyPkmn6.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                 + @"\Pokemon-Simulator\Resources\" + BattleData.enemyList[5].name + "_Pfp.png");
        }

        /// <summary>
        /// Makes the party picture gray so we know that pokemon is fainted
        /// 0 for player, 1 for enemy
        /// </summary>
        private void GrayOutPartyPicture(int mode, int pokemonIndex)
        {
            if(mode == 0)
            {
                if (pokemonIndex == 0) PicBoxPlayerPkmn1.Image = ConvertToGrayScale(PicBoxPlayerPkmn1.Image);
                else if (pokemonIndex == 1) PicBoxPlayerPkmn2.Image = ConvertToGrayScale(PicBoxPlayerPkmn2.Image);
                else if (pokemonIndex == 2) PicBoxPlayerPkmn3.Image = ConvertToGrayScale(PicBoxPlayerPkmn3.Image);
                else if (pokemonIndex == 3) PicBoxPlayerPkmn4.Image = ConvertToGrayScale(PicBoxPlayerPkmn4.Image);
                else if (pokemonIndex == 4) PicBoxPlayerPkmn5.Image = ConvertToGrayScale(PicBoxPlayerPkmn5.Image);
                else if (pokemonIndex == 5) PicBoxPlayerPkmn6.Image = ConvertToGrayScale(PicBoxPlayerPkmn6.Image);
            }
            else
            {
                if (pokemonIndex == 0) PicBoxEnemyPkmn1.Image = ConvertToGrayScale(PicBoxEnemyPkmn1.Image);
                else if (pokemonIndex == 1) PicBoxEnemyPkmn2.Image = ConvertToGrayScale(PicBoxEnemyPkmn2.Image);
                else if (pokemonIndex == 2) PicBoxEnemyPkmn3.Image = ConvertToGrayScale(PicBoxEnemyPkmn3.Image);
                else if (pokemonIndex == 3) PicBoxEnemyPkmn4.Image = ConvertToGrayScale(PicBoxEnemyPkmn4.Image);
                else if (pokemonIndex == 4) PicBoxEnemyPkmn5.Image = ConvertToGrayScale(PicBoxEnemyPkmn5.Image);
                else if (pokemonIndex == 5) PicBoxEnemyPkmn6.Image = ConvertToGrayScale(PicBoxEnemyPkmn6.Image);
            }
            
        }

        private Image ConvertToGrayScale(Image original)
        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                   new float[] {.3f, .3f, .3f, 0, 0},
                   new float[] {.59f, .59f, .59f, 0, 0},
                   new float[] {.11f, .11f, .11f, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {0, 0, 0, 0, 1}
               });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();

            return newBmp;
        }

        #endregion

        #region Party Swtich Methods

        private void PicBoxPlayerPkmn1_Click(object sender, EventArgs e)
        {
            if(BattleData.pokemonList[0].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 0)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(0);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if (requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

        private void PicBoxPlayerPkmn2_Click(object sender, EventArgs e)
        {
            if (BattleData.pokemonList[1].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 1)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(1);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if (requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

        private void PicBoxPlayerPkmn3_Click(object sender, EventArgs e)
        {
            if (BattleData.pokemonList[2].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 2)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(2);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if (requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

        private void PicBoxPlayerPkmn4_Click(object sender, EventArgs e)
        {
            if (BattleData.pokemonList[3].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 3)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(3);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if (requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

        private void PicBoxPlayerPkmn5_Click(object sender, EventArgs e)
        {
            if (BattleData.pokemonList[4].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 4)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(4);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if (requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

        private void PicBoxPlayerPkmn6_Click(object sender, EventArgs e)
        {
            if (BattleData.pokemonList[5].currHealth <= 0)
            {
                LblBattleText.Text = "That Pokemon is unable to battle!";
                return;
            }

            if (activePokemonIndex != 5)
            {
                BattleEventHandler.instance.OnPokemonSwitchOut(activePokemon);
                LoadPlayerPokemonIntoBattle(5);
                if (!requireSwitchIn)
                {
                    selectedMove = -2;
                    StartTurn();
                }
                if(requireSwitchIn)
                {
                    requireSwitchIn = false;
                    UpdateGameState(GameState.PlayerSelectMove);
                }
            }
            else LblBattleText.Text = "That Pokemon is already in battle!";
        }

            #endregion

        }

    public enum GameState
    {
        PlayerSelectMove,
        StartPlayerTurn,
        EndPlayerTurn,
        StartEnemyTurn,
        EndEnemyTurn,
        EndTurn
    }
}