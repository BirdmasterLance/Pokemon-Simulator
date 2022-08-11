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
            health = currHealth = 125*2;
            attack = currAttack = 140;
            defense = currDefense = 90;
            specialAttack = currSpecialAttack = 65;
            specialDefense = currSpecialDefense = 80;
            speed = currSpeed = 120;
            type1 = Type.Fighting;

            moves.Add(new CloseCombat(this));
            moves.Add(new BulkUp(this));
            moves.Add(new ExtremeSpeed(this));
            moves.Add(new Outrage(this));
        }

        public override object Clone()
        {
            var clonedPokemon = (Pokemon)MemberwiseClone();
            List<Move> moves = new List<Move>();
            moves.Add(new CloseCombat(clonedPokemon));
            moves.Add(new BulkUp(clonedPokemon));
            moves.Add(new ExtremeSpeed(clonedPokemon));
            moves.Add(new SuckerPunch(clonedPokemon));
            clonedPokemon.moves = moves;
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
