using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Braixen : Pokemon
    {
        public Braixen() : base()
        {
            name = "Braixen";
            displayName = "Braixen";
            MainColor = Color.LightGoldenrodYellow;

            level = 50;
            health = currHealth = 134*2;
            attack = currAttack = 79;
            defense = currDefense = 78;
            specialAttack = currSpecialAttack = 110;
            specialDefense = currSpecialDefense = 90;
            speed = currSpeed = 93;
            type1 =Type.Fire;

            moves.Add(new CalmMind(this));
            moves.Add(new FireBlast(this));
            moves.Add(new Psychic(this));
            moves.Add(new GrassKnot(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new CalmMind(clonedPokemon));
            moves.Add(new FireBlast(clonedPokemon));
            moves.Add(new Psychic(clonedPokemon));
            moves.Add(new GrassKnot(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }    
}
