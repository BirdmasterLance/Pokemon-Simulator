using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Pokemon_Simulator.PokemonClasses
{
    internal class Alcremie : Pokemon
    {
        public Alcremie()
        {
            name = "Alcremie";
            displayName = "Alcremie";
            MainColor = Color.LightPink;

            level = 50;
            health = 140;
            attack = 80;
            defense = 95;
            specialAttack = 130;
            specialDefense = 141;
            speed = 84;
            type1 = "Fairy";
            type2 = "None";

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
