using Pokemon_Simulator.PokemonClasses;
using Pokemon_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pokemon_Simulator
{
    public partial class MainWindow : Form
    {
        int partyPokemonCounter = 0;
        bool isPlayerSelecting = true;
        int secs = 0;
        List<Pokemon> playerPokemonParty = new List<Pokemon>();
        List<Pokemon> enemyPokemonParty = new List<Pokemon>();

        PictureBox picture1v1 = new System.Windows.Forms.PictureBox();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            PkmnList.Items.Add(new Alcremie());
            PkmnList.Items.Add(new Braixen());
            PkmnList.Items.Add(new Dio());
            PkmnList.Items.Add(new Garou());
            PkmnList.Items.Add(new Gudako());
            PkmnList.Items.Add(new Kasane());
            PkmnList.Items.Add(new Kogami());
            PkmnList.Items.Add(new Mash());
            PkmnList.Items.Add(new Miku());
            PkmnList.Items.Add(new Milotic());
            PkmnList.Items.Add(new Roserade());

            BtnBack.Hide();
        }


        //Form2 namehere

        //Generate 
        //New object using teh new form, and then use the ".Show()" method, and right below it u should use the "Hide()" method so this form disspears.
        // ..Don't forget to use the hide and show in the click method.
        private void button1_Click(object sender, EventArgs e)
        {
            // What happens when u clcik the button.              
            if (!isPlayerSelecting && enemyPokemonParty.Count > 0)
            {
                timer1.Start();
                for (int i= enemyPokemonParty.Count-1; i>=0; i--) {
                    if (enemyPokemonParty[i] != null) { 
                    Pfp_1v1((Pokemon)enemyPokemonParty[i]);
                        label5.Text = "R";
                    }
                }
                // Fill out enemy team
                BattleData.SetEnemyPokemon(enemyPokemonParty);

                
                this.Controls.Remove(PkmnList);
                PartyPkmn.Hide();
                addPokemonButton.Hide();
                removePokemonButton.Hide();
                GbTats.Hide();
                CharacterArea.Hide();
                BtnBack.Hide();
              
                // Hide goes alone since it attempting to hide This form (form 1) jump to form 2
                //works cool 
            }

            if (isPlayerSelecting && playerPokemonParty.Count > 0)
            {
                // FIll out our team
                BattleData.SetPokemon(playerPokemonParty);
                SwitchToEnemySelect();
            }
        }
        // When u remoing a method by just any other way, except by ctr z,  u may generate an error, cause, in this case, it being referenced by the main code

        private void SwitchToPlayerSelect()
        {
            isPlayerSelecting = true;
            this.LblName.BackColor = Color.LightSeaGreen;
            this.LblSlogan.BackColor = Color.LightSeaGreen;
            this.CharacterArea.BackColor = Color.LightSeaGreen;
            this.label2.Text = "Player Party";
            this.BackColor = Color.LightSeaGreen;
            this.GbTats.BackColor = Color.LightSeaGreen;

            // Repopulate the list
            PartyPkmn.Items.Clear();
            foreach (Pokemon pkmn in playerPokemonParty)
            {
                PartyPkmn.Items.Add(pkmn);
            }
        }

        private void SwitchToEnemySelect()
        {
            // Create enemy Team randomly
            //for (int i = 0; i < 6; i++)
            //{
            //    Random rand = new Random();
            //    int randInt = rand.Next(0, enemyPokemonParty.Count - 1);
            //    BattleData.AddEnemyPokemon((Pokemon)enemyPokemonParty[randInt]);
            //}
            //for (int j= 0; j < this.Controls.Count; j++)
            //{

            isPlayerSelecting = false;
            BtnBack.Show();

            this.LblName.BackColor = Color.DarkRed;
            this.LblSlogan.BackColor = Color.DarkRed;
            CharacterArea.BackColor = Color.DarkRed;
            this.label2.Text = "Enemy Party";
            //this.Controls.Clear();
            this.BackColor = Color.IndianRed;
            this.GbTats.BackColor = Color.DarkRed;

            // Repopulate the list
            PartyPkmn.Items.Clear();
            foreach (Pokemon pkmn in enemyPokemonParty)
            {
                PartyPkmn.Items.Add(pkmn);
            }

            //CharacterArea.Hide();
            //Splitter dock = new Splitter();
            //dock.Show();
            //dock.Location = new Point(770);
            //dock.Dock = DockStyle.Right;
            //PkmnList.Location = new Point(1341, PkmnList.Location.Y);
            //GbTats.Location = new Point(80, LblAttack.Location.Y);
            //LblAttack.Location = new Point(80, LblAttack.Location.Y);
            //LblDefense.Location = new Point(80, LblDefense.Location.Y);

            //}
            //foreach(Control control in this)
            //{




            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // same thing, but with the labels, not taht much needed..
        }

        private void PkmnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // For now we gonna use the battle pic until we find actual Pfps
            if (PkmnList.SelectedItem != null)
            {
                UpdateProfile((Pokemon)PkmnList.SelectedItem);
            }
        }

        private void PartyPkmn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartyPkmn.SelectedItem != null)
            {
                UpdateProfile((Pokemon)PartyPkmn.SelectedItem);
            }
        }

        private void UpdateProfile(Pokemon selectedPokemon)
        {
            PbCharacterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            PbCharacterPic.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
            + @"\Pokemon-Simulator\Resources\" + selectedPokemon.name + "_Pfp.png");
            LblName.ForeColor = selectedPokemon.MainColor;
            LblName.Text = selectedPokemon.displayName;
            LblSlogan.Text = "\"" + selectedPokemon.slogan + "\"";
            //if (LblSlogan.Text.Length < 44)
            //{
            //    label5.Text = "Size" + LblSlogan.Text.Length;
            //    LblSlogan.Width = 400;
            //    LblSlogan.Height = 121;


            //}

            LblHP.Text = "HP: " + selectedPokemon.GetHealth();
            LblAttack.Text = "Atk: " + selectedPokemon.GetAttack();
            LblDefense.Text = "Def: " + selectedPokemon.GetDefense();
            LblSpAttack.Text = "Sp. Atk: " + selectedPokemon.GetSpecialAttack();
            LblSpDefense.Text = "Sp. Def: " + selectedPokemon.GetSpecialDefense();
            LblSpeed.Text = "Speed: " + selectedPokemon.GetSpeed();
            LblType.Text = "Type: " + selectedPokemon.type1;
            if (selectedPokemon.type2 != Type.None)
            {
                LblType.Text += ", " + selectedPokemon.type2;
            }
        }

        private void addPokemonButton_Click(object sender, EventArgs e)
        {
            if (partyPokemonCounter < 6 && PkmnList.SelectedItem != null)
            {
                partyPokemonCounter++;
                Pokemon pkmnToAdd = (Pokemon)PkmnList.SelectedItem;
                if (isPlayerSelecting)
                {
                    playerPokemonParty.Add((Pokemon)pkmnToAdd.Clone());
                }
                else
                {
                    enemyPokemonParty.Add((Pokemon)pkmnToAdd.Clone());
                }
                PartyPkmn.Items.Add(PkmnList.SelectedItem);
            }
            label5.Text = partyPokemonCounter.ToString(); ;
        }

        private void removePokemonButton_Click(object sender, EventArgs e)
        {
            if (partyPokemonCounter > 0 && PartyPkmn.SelectedItem != null)
            {
                partyPokemonCounter--;
                if (isPlayerSelecting)
                {
                    playerPokemonParty.Add((Pokemon)PkmnList.SelectedItem);
                }
                else
                {
                    Pokemon pkmnToAdd = (Pokemon)PkmnList.SelectedItem;
                    enemyPokemonParty.Add((Pokemon)pkmnToAdd.Clone());
                }
                PartyPkmn.Items.Remove(PartyPkmn.SelectedItem);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BattleData.SetEnemyPokemon(enemyPokemonParty);
            SwitchToPlayerSelect();
        }


        private void BattleRun(object sender, EventArgs e)
        {
            secs++;
            if (secs >= 50)
            {
                BattleWindow battleWindow = new BattleWindow();
                battleWindow.Show();
                timer1.Stop();
                Hide();
            }
            //label5.Text = "Time= " + secs;
        }
        private void Pfp_1v1(Pokemon pkmn)
        {
            // For now we gonna use the battle pic until we find actual Pfps
            if (PkmnList.SelectedItem != null)
            {
                PbCharacterPic.Size = new Size(this.Size.Width / 2, this.Size.Height);
                PbCharacterPic.Location = new Point(0, 0);


                LblName.ForeColor = pkmn.MainColor;
                LblName.Text = pkmn.displayName;
                LblName.Location = new Point(this.Size.Width / 4, this.Size.Height / 4 + 100);
                LblName.BackColor = Color.Transparent;
                picture1v1.SizeMode = PictureBoxSizeMode.StretchImage;
                picture1v1.Visible = true;
                picture1v1.Enabled = true;
                picture1v1.Size = new Size(this.Size.Width / 2, this.Size.Height);
                picture1v1.Location = new Point(this.Size.Width / 2, 0);
                picture1v1.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + @"\Pokemon-Simulator\Resources\" + pkmn.name + "_Pfp.png");
                picture1v1.Show();
            }
        }

       
        //When removing a button or anythign via here（In the code. And by ctrl z）It may ask u if u are sure of this decision, since it may undo some other actions as well..
    }
}
