using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Roserade : Pokemon
    {
        public Roserade() : base()
        {
            name = "Roserade";
            displayName = "Roserade";
            MainColor = Color.LawnGreen;

            level = 50;
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Grass;
            type2 = Type.Poison;

            moves.Add(new Synthesis(this));
            moves.Add(new SludgeBomb(this));
            moves.Add(new LeafStorm(this));
            moves.Add(new HiddenPower(this, Type.Fire));

            ability = new NaturalCure(this);
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new Synthesis(clonedPokemon));
            moves.Add(new SludgeBomb(clonedPokemon));
            moves.Add(new LeafStorm(clonedPokemon));
            moves.Add(new HiddenPower(clonedPokemon, Type.Fire));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            clonedPokemon.ability = new NaturalCure(clonedPokemon);
            return clonedPokemon;
        }
    }
}
