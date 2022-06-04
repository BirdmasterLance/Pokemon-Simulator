﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        Pokemon activeEnemyPokemon;
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
            LoadPlayerPokemonIntoBattle(BattleData.pokemonList[0]);

            lblMCY.Show();
            lblMCY.Location = new Point(500, 50);

            lblMCX.Show();
            lblMCX.Location = new Point(500, 20);

            LoadEnemyPokemonIntoBattle(BattleData.enemyList[0]);
            //TODO: Event for Image Resizing.(Scaling) Item re-placeement depenign on the screen size.

            LblPlayerStatus.Hide();
            LblEnemyStatus.Hide();
            Comment.Hide();

            //Let this class listen to battle events?
            BattleEventHandler.instance.OnStartPlayerTurn += PlayerTurn;
            BattleEventHandler.instance.OnStartEnemyTurn += EnemyTurn;
        }

        private void LoadPlayerPokemonIntoBattle(Pokemon pokemon)
        {
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

        private void LoadEnemyPokemonIntoBattle(Pokemon pokemon)
        {
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
        }

        private void Move1_Click(object sender, EventArgs e)
        {
            if (moves[0].pp > 0 && !coolDown)
            {
                moves[0].pp--;
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
                moves[1].pp--;
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
                moves[2].pp--;
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
            //System.Timers.Timer attackTimer = new System.Timers.Timer(1000);
            //attackTimer.Elapsed += PlayerAttackAnimation;

            //playerPokemonImage.Location = Point.;//This sets the location of the Left top corner of the item in estion, the image, in this case            
            //Console.WriteLine(activePokemon.currAttack + " " + activePokemon.currDefense + " " + activePokemon.currSpecialAttack + " " + activePokemon.currSpecialDefense + " " + activePokemon.currSpeed);
            if (selectedMove != -1)
            {
                // Damage the enemy
                int damage = activePokemon.UseMove(moves[selectedMove], activeEnemyPokemon);
                label1.Text = activePokemon.name + " used " + moves[selectedMove].moveName;
                if (damage >= 0)
                {
                    label1.Text += " dealing " + damage + " damage!";
                } 
                else
                {
                    label1.Text += "!"; // will optimize this part later
                }
            }
            else
            {
                Move struggle = new Struggle(/*ref*/ activePokemon);
                int damage = activePokemon.UseMove(struggle, activeEnemyPokemon);
            }
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            activeEnemyPokemon.knownMoves.Add(activePokemon.moves[selectedMove]);
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
            // if ( activePokemon.UseMove(moves[selectedMove], activeEnemyPokemon)< activeEnemyPokemon.GetHealth() * 20 / 100){
            //
            //     Comment.Text = activeEnemyPokemon.GetComment()[4];
            // }



        }
        private void EnemyTurn(object sender, EventArgs e)
        {
            //timer1.Start();

            //secs = 0;


            if (!EcoolDown)
            {
                // Now that selectedMove is global, we can put this here


                activeEnemyPokemon.AICPU(playerFirst);



                //AttackAnimation(playerPokemonImage, -1);h
                if (!NoMoreMoves(activeEnemyPokemon))
                {
                    // Damage the player
                    //int damage = activeEnemyPokemon.UseMove(activeEnemyPokemon.moves[move], activePokemon);
                    //label3.Text = activeEnemyPokemon.GetHealth().ToString() + " " + activeEnemyPokemon.currHealth.ToString() + " " + activeEnemyPokemon.GetDamage();
                    label3.Text = activeEnemyPokemon.name + " used " + activeEnemyPokemon.lastUsedMove.moveName;
                    if (activeEnemyPokemon.GetDamage() > 0)
                    {
                        label3.Text += " dealing " + activeEnemyPokemon.GetDamage() + " damage!";
                    }
                    else
                    {
                        label3.Text += "!";
                    }
                }
                else
                {
                    //int damage = activeEnemyPokemon.UseMove(new Struggle(activeEnemyPokemon), activePokemon);
                }
            }
            UpdateHealthBar(0);
            UpdateHealthBar(1);
            EcoolDown = true;
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
                LblStats.Text = activePokemon.currAttack + " " + activePokemon.GetAttack() + "\n" +
                    activePokemon.currDefense + " " + activePokemon.GetDefense() + "\n" +
                    activePokemon.currSpecialAttack + " " + activePokemon.GetSpecialAttack() + "\n" +
                    activePokemon.currSpecialDefense + " " + activePokemon.GetSpecialDefense() + "\n" +
                    activePokemon.currSpeed + " " + activePokemon.GetSpeed();
                label1.Text = "";
                label3.Text = "";

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
    }
}
