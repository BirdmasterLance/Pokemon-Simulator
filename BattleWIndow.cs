using System;
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

        ComponentResourceManager resources = new ComponentResourceManager(typeof(BattleWindow));


        Pokemon activePokemon;
        int activePokemonIndex;
        Pokemon activeEnemyPokemon;
        int activeEnemyPokemonIndex;
        int selectedMove;

        Label lblMCX = new Label();
        Label lblMCY = new Label();
        List<Move> moves = new List<Move>();

        int turnCounter = 0;
        int secs = 0;
        bool playerFirst;

        bool coolDown;
        bool EcoolDown;

        Random rand = new Random();
        public BattleWindow()
        {
            InitializeComponent();
        }

        //Am assuming this where battle begins, so add buttons and such, might as well say that u can experiment
        private void BattleWindow_Load(object sender, EventArgs e)
        {
            LoadPlayerPokemonIntoBattle(0);

            lblMCY.Show();
            lblMCY.Location = new Point(500, 50);

            lblMCX.Show();
            lblMCX.Location = new Point(500, 20);

            LoadEnemyPokemonIntoBattle(0);
            //TODO: Event for Image Resizing.(Scaling) Item re-placeement depenign on the screen size.

            LoadPartyPictures();

            LblPlayerStatus.Hide();
            LblEnemyStatus.Hide();
            Comment.Hide();

            //Let this class listen to battle events?
            BattleEventHandler.instance.OnStartPlayerTurn += PlayerTurn;
            BattleEventHandler.instance.OnStartEnemyTurn += EnemyTurn;
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

            BattleEventHandler.instance.StartPokemonSwitchIn(activePokemon);

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

            // Now the enemy knows this pokemon 
            activeEnemyPokemon.knownPokemons.Add(activePokemon);
            activeEnemyPokemon.SetRivalPokemon(activePokemon);

            BattleEventHandler.instance.StartPokemonSwitchIn(activeEnemyPokemon);
        }

        private void Move1_Click(object sender, EventArgs e)
        {
            if (moves[0].pp > 0 && !coolDown)
            {
                Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
                selectedMove = 0;
                StartTurn();
            }

            // No more moves? Struggle.
            if (NoMoreMoves(activePokemon)) selectedMove = -1;
        }

        private void Move2_Click(object sender, EventArgs e)
        {
            if (moves[1].pp > 0 && !coolDown)
            {
                Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
                selectedMove = 1;
                StartTurn();
            }

            if (NoMoreMoves(activePokemon)) selectedMove = -1;
        }

        private void Move3_Click(object sender, EventArgs e)
        {
            if (moves[2].pp > 0 && !coolDown)
            {
                Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
                selectedMove = 2;
                StartTurn();
            }

            if (NoMoreMoves(activePokemon)) selectedMove = -1;
        }

        private void Move4_Click(object sender, EventArgs e)
        {
            if (moves[3].pp > 0 && !coolDown)
            {
                moves[3].pp--;
                Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
                selectedMove = 3;
                StartTurn();
            }

            if (NoMoreMoves(activePokemon)) selectedMove = -1;
        }

        private void StartTurn()
        {
            turnCounter++; // We are in the "next" turn
            playerFirst = activePokemon.currSpeed >= activeEnemyPokemon.currSpeed;
            Console.WriteLine(turnCounter + " " + playerFirst);
            Commentary_Battle();
            timer1.Start();
            coolDown = true;
        }

        private void PlayerTurn(object sender, EventArgs e)
        { 
            if (selectedMove != -1)
            {
                // Damage the enemy
                int damage = activePokemon.UseMove(moves[selectedMove], activeEnemyPokemon);
                label1.Text = activePokemon.name + " used " + moves[selectedMove].moveName;
                if (damage >= 0) { label1.Text += " dealing " + damage + " damage!"; } 
                else { label1.Text += "!"; }
            }
            else
            {
                Move struggle = new Struggle(/*ref*/ activePokemon);
                int damage = activePokemon.UseMove(struggle, activeEnemyPokemon);
            }
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            activeEnemyPokemon.knownMoves.Add(activePokemon.moves[selectedMove]);

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
            if (activePokemon.GetDamage(moves[selectedMove], activeEnemyPokemon) < activeEnemyPokemon.GetHealth() * 20 / 100)
            {
                Comment.Text = activeEnemyPokemon.GetComment()[4];
            }
        }

        private void EnemyTurn(object sender, EventArgs e)
        {
            if (!EcoolDown)
            {
                // Now that selectedMove is global, we can put this here
                activeEnemyPokemon.AICPU(playerFirst);

                //AttackAnimation(playerPokemonImage, -1);h
                if (!NoMoreMoves(activeEnemyPokemon))
                {
                    // Damage the player                   
                    label1.Text = activeEnemyPokemon.name + " used " + activeEnemyPokemon.lastUsedMove.moveName;
                    if (activeEnemyPokemon.GetDamage() > 0) { label1.Text += " dealing " + activeEnemyPokemon.GetDamage() + " damage!"; }
                    else { label1.Text += "!"; }
                }
                else
                {
                    //int damage = activeEnemyPokemon.UseMove(new Struggle(activeEnemyPokemon), activePokemon);
                }
            }
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            EcoolDown = true;

            //if the enemy used a move that changed their stats, display it here
            UpdateStatLabel();
        }

        private void PlayerAttackAnimation(Object source, ElapsedEventArgs e)
        {

        }

        private void HurtAnimation(PictureBox picture)
        {

        }

        private bool NoMoreMoves(Pokemon pkmn)
        {
            return pkmn.moves[0].pp == 0 && pkmn.moves[1].pp == 0 && pkmn.moves[2].pp == 0 && pkmn.moves[3].pp == 0;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            secs++;
            //Console.WriteLine(secs);
            if(playerFirst)
            {
                if (secs == 10)
                {
                    BattleEventHandler.instance.StartPlayerTurn();
                }
                else if (secs == 50)
                {
                    BattleEventHandler.instance.EndPlayerTurn();
                    // if (CheckFainted() == 0) for when we die during out turn (like recoil)
                    if (CheckFainted() == 1) // the enemy has fainted before their turn, skip theirs
                    {
                        // TODO: methods for enemy switching out
                        GrayOutPartyPicture(1, activeEnemyPokemonIndex);
                        label1.Text = activeEnemyPokemon.displayName + " has fainted!";
                        secs = 151;
                    }
                }
                else if (secs == 100)
                {
                    Comment.Hide();
                    EcoolDown = false;
                    BattleEventHandler.instance.StartEnemyTurn();
                }
                else if (secs == 150)
                {
                    BattleEventHandler.instance.EndEnemyTurn();
                }
            }
            else
            {
                if (secs == 10)
                {
                    Comment.Hide();
                    EcoolDown = false;
                    BattleEventHandler.instance.StartEnemyTurn();
                }
                else if (secs == 50)
                {
                    BattleEventHandler.instance.EndEnemyTurn();
                    // if (CheckFainted() == 1) for when the enemy dies during out turn (like recoil)
                    if (CheckFainted() == 0) // the player has fainted before their turn, skip theirs
                    {
                        GrayOutPartyPicture(0, activePokemonIndex);
                        label1.Text = activePokemon.displayName + " has fainted!";
                        secs = 151;
                    }
                }
                else if (secs == 100)
                {
                    BattleEventHandler.instance.StartPlayerTurn();
                }
                else if (secs == 150)
                {
                    BattleEventHandler.instance.EndPlayerTurn();                  
                }
            }
            
            if (secs == 200)
            {
                BattleEventHandler.instance.EndTurn();
               
                UpdateHealthBar(0);
                UpdateHealthBar(1);               
                label1.Text = "";

                // Update the move counter at the end incase it doesnt update earlier
                Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
                Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
                Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
                Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();

                coolDown = false;
                secs = 0;
                timer1.Stop();
            }

        }       

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
        
        private int CheckFainted()
        {
            // if one of the pokemon has lost all of their HP, raise the event so other classes know a pokemon has fainted
            if(activePokemon.currHealth <= 0)
            {
                BattleEventHandler.instance.PlayerPokemonFainted(activePokemon);
                return 0; // 0 for the player
            }

            if(activeEnemyPokemon.currHealth <= 0)
            {
                BattleEventHandler.instance.PlayerPokemonFainted(activeEnemyPokemon);
                return 1; // 1 for the enemy
            }
            return -1; // no one has fainted yet
        }

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

    }
}
