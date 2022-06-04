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
        public Alcremie() : base()
        {
            name = "Alcremie";
            displayName = "Alcremie";
            MainColor = Color.LightPink;

            level  = 50;
            health = currHealth = 140;
            attack = currAttack = 80;
            defense = currDefense = 95;
            specialAttack = currSpecialAttack = 130;
            specialDefense = currSpecialDefense = 141;
            speed = currSpeed = 84;
            type1 = Type.Fairy;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));

            //item = new Leftovers(this);
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new DazzlingGleam(clonedPokemon));
            moves.Add(new MysticalFire(clonedPokemon));
            moves.Add(new Recover(clonedPokemon));
            moves.Add(new CalmMind(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = new Leftovers(clonedPokemon);
            return clonedPokemon;
        }
    }
}
