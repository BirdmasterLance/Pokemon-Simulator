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
        public Garou() : base()
        {
            name = "Garou";
            displayName = "Garou";
            MainColor = Color.PaleVioletRed;
            slogan = "The popular will win, the hated will lose.";

            level = 50;
            health = currHealth = 125;
            attack = currAttack = 140;
            defense = currDefense = 90;
            specialAttack = currSpecialAttack = 65;
            specialDefense = currSpecialDefense = 80;
            speed = currSpeed = 120;
            type1 = "Fighting";
            type2 = "None";

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
