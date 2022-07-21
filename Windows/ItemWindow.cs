using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Simulator.Windows
{
    public partial class ItemWindow : Form
    {
        Pokemon selectedPokemon;
        public ItemWindow(Pokemon selectedPokemon)
        {
            InitializeComponent();
            this.selectedPokemon = selectedPokemon;

            if(selectedPokemon.item != null)
            {
                LblCurrItem.Text = "Current Item: " + selectedPokemon.item.itemName;
            }
            else
            {
                LblCurrItem.Text = "Current Item: None";
            }

            LstBxItems.Items.Add(new LifeOrb());
            LstBxItems.Items.Add(new ChoiceScarf());
            LstBxItems.Items.Add(new ChoiceBand());
            LstBxItems.Items.Add(new ChoiceSpecs());
            LstBxItems.Items.Add(new Leftovers());

            this.FormClosed += new FormClosedEventHandler(ClearList);           
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(LstBxItems.SelectedItem != null)
            {
                Item item = (Item)LstBxItems.SelectedItem;
                item.SetHolder(selectedPokemon);
                selectedPokemon.item = item;
                LblCurrItem.Text = "Current Item: " + selectedPokemon.item.itemName;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            selectedPokemon.item = null;
            LblCurrItem.Text = "Current Item: None";
        }

        private void LstBxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = (Item)LstBxItems.SelectedItem;
            LblDescription.Text = "Description:\n" + item.description;
        }

        private void ClearList(object sender, EventArgs e)
        {
            LstBxItems.Items.Clear();
        }
    }
}
