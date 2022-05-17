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

namespace Pokemon_Simulator.Properties
{
    public partial class BattleWindow : Form
    {

        Pokemon activePokemon;
        Pokemon activeEnemyPokemon;

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
            Move1.Text = moves[0].moveName + '\n' + moves[0].pp.ToString() + "/" + moves[0].maxPP.ToString();
            Move2.Text = moves[1].moveName + '\n' + moves[1].pp.ToString() + "/" + moves[1].maxPP.ToString();
            Move3.Text = moves[2].moveName + '\n' + moves[2].pp.ToString() + "/" + moves[2].maxPP.ToString();
            Move4.Text = moves[3].moveName + '\n' + moves[3].pp.ToString() + "/" + moves[3].maxPP.ToString();
            PlayerPokemon.Text = activePokemon.name;
            progressBar3.Maximum = (int) activePokemon.health;
            progressBar3.Value = (int) activePokemon.currHealth;
            PlayerHealth.Text = activePokemon.currHealth + "/" + activePokemon.health;

            playerPokemonImage.SizeMode = PictureBoxSizeMode.Zoom;
            //Since u may need pc boxes After u do stff 
            playerPokemonImage.Load(AppDomain.CurrentDomain.BaseDirectory + activePokemon.imageDirectory);//Try this?
            //
            activeEnemyPokemon = BattleData.enemyList[0];
            EnemyName.Text = activeEnemyPokemon.name;
            progressBar2.Maximum = (int) activeEnemyPokemon.health;
            progressBar2.Value = (int) activeEnemyPokemon.currHealth;
            //Use any method 
            enemyPokemonImage.SizeMode = PictureBoxSizeMode.Zoom;
            Image enemyImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + activeEnemyPokemon.imageDirectory);
            enemyPokemonImage.Image = enemyImage;
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
                    progressBar2.Value = (int) activeEnemyPokemon.currHealth;
                }
                else
                {
                    progressBar2.Value = 0;
                }
            }
            else
            {
                int damage = activePokemon.UseMove(new Struggle(activePokemon), activeEnemyPokemon);
                if (activeEnemyPokemon.currHealth > 0)
                {
                    progressBar2.Value = (int) activeEnemyPokemon.currHealth;
                }
                else
                {
                    progressBar2.Value = 0;
                }
            }

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
                label3.Text = activeEnemyPokemon.health.ToString() + " " + activeEnemyPokemon.currHealth.ToString() + " " + damage;
                if (activeEnemyPokemon.currHealth > 0)
                {
                    progressBar3.Value = (int) activePokemon.currHealth;
                    PlayerHealth.Text = activePokemon.currHealth + "/" + activePokemon.health;
                }
                else
                {
                    progressBar3.Value = 0;
                    PlayerHealth.Text = "0/" + activePokemon.health;

                }
            }
            else
            {
                int damage = activeEnemyPokemon.UseMove(new Struggle(activeEnemyPokemon), activePokemon);
                if (activeEnemyPokemon.currHealth > 0)
                {
                    progressBar3.Value = (int) activePokemon.currHealth;
                    PlayerHealth.Text = activePokemon.currHealth + "/" + activePokemon.health;
                }
                else
                {
                    progressBar3.Value = 0;
                    PlayerHealth.Text = "0/" + activePokemon.health;

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

    }
}
