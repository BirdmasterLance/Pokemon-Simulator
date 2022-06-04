using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Dio : Pokemon
    {
        public Dio() : base()
        {
            name = "Dio";
            displayName = "DIO";
            MainColor = Color.Gold;
            slogan = "How many slices of bread?";
            font = new Font("Arial",10);

            comments[0] = "Is that it?";
            comments[1] = "Muda!";
            comments[4] = "Kono Dio Da!";

            level = 50;
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Dark;

            moves.Add(new IceBeam(this));
            moves.Add(new CloseCombat(this));
            moves.Add(new Recover(this));
            moves.Add(new Toxic(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new IceBeam(clonedPokemon));
            moves.Add(new CloseCombat(clonedPokemon));
            moves.Add(new Recover(clonedPokemon));
            moves.Add(new Toxic(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
