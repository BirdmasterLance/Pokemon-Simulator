using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Mash : Pokemon
    {
        public Mash() : base()
        {
            name = "Mash";
            displayName = "Mash Kyrielight";
            MainColor = Color.Pink;

            level = 50;
            health = currHealth = 150*2;
            attack = currAttack = 95;
            defense = currDefense = 130;
            specialAttack = currSpecialAttack = 70;
            specialDefense = currSpecialDefense = 105;
            speed = currSpeed = 90;
            type1 = Type.Steel;

            moves.Add(new IronHead(this));
            moves.Add(new MeteorMash(this));
            moves.Add(new IronDefense(this));
            moves.Add(new Earthquake(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new IronHead(clonedPokemon));
            moves.Add(new MeteorMash(clonedPokemon));
            moves.Add(new IronDefense(clonedPokemon));
            moves.Add(new Earthquake(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
