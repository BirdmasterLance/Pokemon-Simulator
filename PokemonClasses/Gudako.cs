using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Gudako : Pokemon
    {
        public Gudako() : base()
        {
            name = "Gudako";
            displayName = "Gudako";
            MainColor = Color.Orange;

            comments[0] = "Take That!";
            comments[1] = "Great！";
            comments[2] = "How Come?!";
            comments[3] = "How Dare You!?";
            comments[4] = "It Aint Overr.. yet.";
            level = 50;
            health = currHealth = 120*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 80;
            specialDefense = currSpecialDefense = 85;
            speed = currSpeed = 80;
            type1 = Type.Normal;

            moves.Add(new Headbutt(this));
            moves.Add(new BulkUp(this));
            moves.Add(new Recover(this));
            moves.Add(new WorkUp(this));

            //item = new ChoiceScarf(this);
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new Headbutt(clonedPokemon));
            moves.Add(new BulkUp(clonedPokemon));
            moves.Add(new Recover(clonedPokemon));
            moves.Add(new WorkUp(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = new ChoiceScarf(clonedPokemon);
            return clonedPokemon;
        }
    }
}
