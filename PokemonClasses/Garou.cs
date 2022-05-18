using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator.PokemonClasses
{
    internal class Garou : Pokemon
    {
        public Garou()
        {
            name = "Garou";
            displayName = "Garou";
            level = 50;
            health = 125;
            attack = 58;
            defense = 72;
            specialAttack = 103;
            specialDefense = 113;
            speed = 62;
            type1 = "Fighting";
            type2 = "None";

            slogan = "The popular will win, the hated will lose.";

            currHealth = health;
            currDefense = defense;
            currAttack = attack;
            currSpecialAttack = specialAttack;
            currSpeed = speed;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
