using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace Pokemon_Simulator.Properties
{
    public partial class BattleWindow : Form
    {

        ComponentResourceManager resources = new ComponentResourceManager(typeof(BattleWindow));

        Pokemon activePokemon;
        Pokemon activeEnemyPokemon;

        Label lblMCX = new Label();
        Label lblMCY = new Label();
        List<Move> moves = new List<Move>();

        int turnCounter = 0;
        bool playerFirst;

        public BattleWindow()
        {
            InitializeComponent();
        }


        //Am assuming this where battle begins, so add buttons and such, might as well say that u can experiment
        private void BattleWindow_Load(object sender, EventArgs e)
        {
            // probs change the text of the buttons here H
            activePokemon = BattleData.pokemonList[0];
            moves = activePokemon.moves;            
            LoadPlayerPokemonIntoBattle(activePokemon);

            
            
            lblMCY.Show();


            lblMCY.Location = new Point(500, 50);

           
            lblMCX.Show();


            lblMCX.Location = new Point(500, 20);
            activeEnemyPokemon = BattleData.enemyList[0];
            LoadEnemyPokemonIntoBattle(activeEnemyPokemon);
            playerPokemonName.ForeColor= activePokemon.MainColor;
            //TODO: Event for Image Resizing.(Scaling) Item re-placeement depenign on the screen size.
        }

        private void LoadPlayerPokemonIntoBattle(Pokemon pokemon)
        {
            playerPokemonName.Text = pokemon.displayName;
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
        }

        private void LoadPlayerMoves(List<Move> moves)
        {
            // If they have less than 4 moves, make sure we are not trying to access elements that don't exist
            if(moves.Count >= 1) Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
            if(moves.Count >= 2) Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
            if(moves.Count >= 3) Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
            if(moves.Count >= 4) Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
        }

        private void LoadEnemyPokemonIntoBattle(Pokemon pokemon)
        {
            enemyPokemonName.Text = pokemon.displayName;
            enemyHealthBar.Maximum = (int)pokemon.GetHealth();
            enemyHealthBar.Value = (int)pokemon.currHealth;

            enemyPokemonImage.SizeMode = PictureBoxSizeMode.Zoom;
            // Get the directory of the actual project, then get the resources folder
            enemyPokemonImage.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + @"\Pokemon-Simulator\Resources\" + pokemon.name + "_Battle.png");
        }

        private void Move1_Click(object sender, EventArgs e)
        {
            if(moves[0].pp > 0)
            {
                moves[0].pp--;
                Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
                StartTurn(0);
            }

            // No more moves? Struggle.
            if (NoMoreMoves(activePokemon)) StartTurn(-1);
        }

        private void Move2_Click(object sender, EventArgs e)
        {
            if(moves[1].pp > 0)
            {
                moves[1].pp--;
                Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
                StartTurn(1);
            }

            if (NoMoreMoves(activePokemon)) StartTurn(-1);
        }

        private void Move3_Click(object sender, EventArgs e)
        {
            if(moves[2].pp > 0)
            {
                moves[2].pp--;
                Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
                StartTurn(2);
            }

            if (NoMoreMoves(activePokemon)) StartTurn(-1);
        }

        private void Move4_Click(object sender, EventArgs e)
        {
            if(moves[3].pp > 0)
            {
                moves[3].pp--;
                Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
                StartTurn(3);
            }

            if (NoMoreMoves(activePokemon)) StartTurn(-1);
        }

        private void StartTurn(int move)
        {
            turnCounter++; // We are in the "next" turn

            if(activePokemon.currSpeed >= activeEnemyPokemon.currSpeed)
            {
                playerFirst = true;
                PlayerTurn(move);
            }
            else
            {
                playerFirst = false;
                EnemyTurn(move);
            }
        }

        private void PlayerTurn(int move)
        {
            //System.Timers.Timer attackTimer = new System.Timers.Timer(1000);
            //attackTimer.Elapsed += PlayerAttackAnimation;

            //playerPokemonImage.Location = Point.;//This sets the location of the Left top corner of the item in estion, the image, in this case

            if (move != -1)
            {
                // Damage the enemy
                int damage = activePokemon.UseMove(moves[move], activeEnemyPokemon);
                if (activeEnemyPokemon.currHealth > 0)
                {
                    enemyHealthBar.Value = (int) activeEnemyPokemon.currHealth;
                }
                else
                {
                    enemyHealthBar.Value = 0;
                }
            }
            else
            {
                int damage = activePokemon.UseMove(new Struggle(activePokemon), activeEnemyPokemon);
                if (activeEnemyPokemon.currHealth > 0)
                {
                    enemyHealthBar.Value = (int) activeEnemyPokemon.currHealth;
                }
                else
                {
                    enemyHealthBar.Value = 0;
                }
            }
            activeEnemyPokemon.knownMoves.Add(activePokemon.moves[move]);

            // TODO: item check here

            if(playerFirst) EnemyTurn(move);
        }

        private void EnemyTurn(int move)
        {
            //AttackAnimation(playerPokemonImage, -1);
            if (!NoMoreMoves(activeEnemyPokemon))
            {
                // Damage the player
                int damage = activeEnemyPokemon.UseMove(activeEnemyPokemon.moves[move], activePokemon);
                label3.Text = activeEnemyPokemon.GetHealth().ToString() + " " + activeEnemyPokemon.currHealth.ToString() + " " + damage;
                if (activeEnemyPokemon.currHealth > 0)
                {
                    playerHealthBar.Value = (int) activePokemon.currHealth;
                    playerHealthText.Text = (int)activePokemon.currHealth + "/" + activePokemon.GetHealth();
                }
                else
                {
                    playerHealthBar.Value = 0;
                    playerHealthText.Text = "0/" + activePokemon.GetHealth();

                }
            }
            else
            {
                int damage = activeEnemyPokemon.UseMove(new Struggle(activeEnemyPokemon), activePokemon);
                if (activeEnemyPokemon.currHealth > 0)
                {
                    playerHealthBar.Value = (int) activePokemon.currHealth;
                    playerHealthText.Text = activePokemon.currHealth + "/" + activePokemon.GetHealth();
                }
                else
                {
                    playerHealthBar.Value = 0;
                    playerHealthText.Text = "0/" + activePokemon.GetHealth();

                }
            }

            if(!playerFirst) PlayerTurn(move);
        }

        private void PlayerAttackAnimation(Object source, ElapsedEventArgs e)
        {

        }

        private void HurtAnimation(PictureBox picture)
        {

        }

        private bool NoMoreMoves(Pokemon pkmn)
        {
            List<Move> moves = pkmn.moves;
            return moves[0].pp == 0 && moves[1].pp == 0 && moves[2].pp == 0 && moves[3].pp == 0;
        }
        void ResizeScreen(Object source, EventArgs e)
        {
            enemyHealthBar.Location = new Point(this.Location.X+700, this.Location.Y+20);

        }
        void MouseCoord(Object source, MouseEventArgs e)
        {
           label3.Text= "Xpos: "+e.X.ToString() + "Ypos: "+e.Y.ToString();

            lblMCY.Text = e.Y.ToString();


        }

    }
}
