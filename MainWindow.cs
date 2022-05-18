using Pokemon_Simulator.PokemonClasses;
using Pokemon_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Simulator
{
    public partial class MainWindow : Form
    {
        int partyPokemonCounter = 0;
        Pokemon selectedPokemon;

        List<Pokemon> listForEnemy = new List<Pokemon>();

        public MainWindow()
        {
            InitializeComponent();

            PkmnList.Items.Add(new Alcremie());

            listForEnemy.Add(new Alcremie());
        }


       //Form2 namehere
        
        //Generate 
        //New object using teh new form, and then use the ".Show()" method, and right below it u should use the "Hide()" method so this form disspears.
        // ..Don't forget to use the hide and show in the click method.
        private void button1_Click(object sender, EventArgs e)
        {
            // What happens when u clcik the button.

            // FIll out our team
            foreach(Pokemon pkmn in PartyPkmn.Items)
            {
                BattleData.AddPokemon(pkmn);
            }
            
            // Create enemy Team
            for(int i = 0; i < 6; i++)
            {
                Random rand = new Random();
                int randInt = rand.Next(0, listForEnemy.Count-1);
                BattleData.AddEnemyPokemon((Pokemon) listForEnemy[randInt]);
            }

            BattleWindow battleWindow = new BattleWindow();
            battleWindow.Show();
            Hide();// Hide goes alone since it attempting to hide This form (form 1) jump to form 2
            //works cool 
        }
        // When u remoing a method by just any other way, except by ctr z,  u may generate an error, cause, in this case, it being referenced by the main code

        private void label1_Click(object sender, EventArgs e)
        {
            // same thing, but with the labels, not taht much needed..
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPokemon = (Pokemon) PkmnList.SelectedItem;
            if (partyPokemonCounter >= 6)
            {
                PartyPkmn.SelectedItem = selectedPokemon;
            }
            else
            {
                partyPokemonCounter++;
                if(PkmnList.SelectedItem != null) { 
                PartyPkmn.Items.Add(PkmnList.SelectedItem);
                }
            }
            label5.Text = partyPokemonCounter.ToString(); ;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartyPkmn.SelectedItem != null)
            {

                partyPokemonCounter--;
                PartyPkmn.Items.Remove(PartyPkmn.SelectedItem);
            }
        }

        private void updateProfile(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        //When removing a button or anythign via here（In the code. And by ctrl z）It may ask u if u are sure of this decision, since it may undo some other actions as well..
    }
}
