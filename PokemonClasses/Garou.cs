using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    internal class Garou : Pokemon
    {
        public Garou()
        {
            name = "Garou";
            displayName = "Garou";
            MainColor = Color.PaleVioletRed;
            slogan = "The popular will win, the hated will lose.";

            level = 50;
            health = 125;
            attack = 140;
            defense = 90;
            specialAttack = 65;
            specialDefense = 80;
            speed = 120;
            type1 = "Fighting";
            type2 = "None";

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
