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

        List<Pokemon> listForEnemy = new List<Pokemon>();

        public MainWindow()
        {
            InitializeComponent();

            PkmnList.Items.Add(new Alcremie());
            PkmnList.Items.Add(new Garou());
            PkmnList.Items.Add(new Kasane());

            listForEnemy.Add(new Alcremie());
            listForEnemy.Add(new Garou());
            listForEnemy.Add(new Kasane());
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }


        //Form2 namehere

        //Generate 
        //New object using teh new form, and then use the ".Show()" method, and right below it u should use the "Hide()" method so this form disspears.
        // ..Don't forget to use the hide and show in the click method.
        private void button1_Click(object sender, EventArgs e)
        {
            // What happens when u clcik the button.

            // FIll out our team
            foreach (Pokemon pkmn in PartyPkmn.Items)
            {
                BattleData.AddPokemon(pkmn);
            }

            // Create enemy Team
            for (int i = 0; i < 6; i++)
            {
                Random rand = new Random();
                int randInt = rand.Next(0, listForEnemy.Count - 1);
                BattleData.AddEnemyPokemon((Pokemon)listForEnemy[randInt]);
            }
            //for (int j= 0; j < this.Controls.Count; j++)
            //{

            this.LblName.BackColor = Color.DarkRed;
            this.LblSlogan.BackColor = Color.DarkRed;
            CharacterArea.BackColor = Color.DarkRed;
            this.label2.Text = "Enemy Party";
            //this.Controls.Clear();
            this.BackColor = Color.IndianRed;
            this.GbTats.BackColor = Color.DarkRed;
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


            BattleWindow battleWindow = new BattleWindow();
            ////battleWindow.Show();
            ////Hide();// Hide goes alone since it attempting to hide This form (form 1) jump to form 2
            //works cool 
        }
        // When u remoing a method by just any other way, except by ctr z,  u may generate an error, cause, in this case, it being referenced by the main code

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
            PbCharacterPic.SizeMode = PictureBoxSizeMode.Zoom;
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
            if (selectedPokemon.type2 != "None")
            {
                LblType.Text += ", " + selectedPokemon.type2;
            }
        }

        private void addPokemonButton_Click(object sender, EventArgs e)
        {
            if (partyPokemonCounter < 6 && PkmnList.SelectedItem != null)
            {
                partyPokemonCounter++;
                PartyPkmn.Items.Add(PkmnList.SelectedItem);
            }
            label5.Text = partyPokemonCounter.ToString(); ;
        }

        private void removePokemonButton_Click(object sender, EventArgs e)
        {
            if (partyPokemonCounter > 0 && PartyPkmn.SelectedItem != null)
            {
                partyPokemonCounter--;
                PartyPkmn.Items.Remove(PartyPkmn.SelectedItem);
            }
        }

        //When removing a button or anythign via here（In the code. And by ctrl z）It may ask u if u are sure of this decision, since it may undo some other actions as well..
    }
}
