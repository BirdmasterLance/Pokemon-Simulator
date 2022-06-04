using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Miku : Pokemon
    {
        public Miku() : base()
        {
            name = "Miku";
            displayName = "Hatsune Miku";
            MainColor = Color.Aquamarine;

            level = 50;
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Fairy;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new HyperVoice(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new DazzlingGleam(clonedPokemon));
            moves.Add(new HyperVoice(clonedPokemon));
            moves.Add(new Recover(clonedPokemon));
            moves.Add(new CalmMind(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
