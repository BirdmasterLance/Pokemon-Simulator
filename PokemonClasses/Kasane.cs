using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Pokemon_Simulator.PokemonClasses
{
    internal class Kasane : Pokemon
    {
        public Kasane()
        {
            name = "Kasane";
            displayName = "Kasane Teto";
            MainColor = Color.Pink;

            level = 50;
            health = 125;
            attack = 58;
            defense = 72;
            specialAttack = 103;
            specialDefense = 113;
            speed = 62;
            type1 = "Fairy";
            type2 = "None";          

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
