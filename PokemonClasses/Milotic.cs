using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Milotic : Pokemon
    {
        public Milotic() : base()
        {
            name = "Milotic";
            displayName = "Milotic";
            MainColor = Color.RoyalBlue;
            slogan = "このワルドは。。";

            level = 50;
            health = currHealth = 170;
            attack = currAttack = 80;
            defense = currDefense = 99;
            specialAttack = currSpecialAttack = 120;
            specialDefense = currSpecialDefense = 145;
            speed = currSpeed = 101;
            type1 = Type.Water;

            moves.Add(new Scald(this));
            moves.Add(new Recover(this));
            moves.Add(new Toxic(this));
            moves.Add(new IceBeam(this));
            moves.Add(new RainDance(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new Scald(clonedPokemon));
            moves.Add(new Recover(clonedPokemon));
            //moves.Add(new Toxic(clonedPokemon));
            moves.Add(new TestMove(clonedPokemon));
            moves.Add(new IceBeam(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
