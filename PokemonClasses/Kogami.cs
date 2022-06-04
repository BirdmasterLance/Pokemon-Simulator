using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Kogami : Pokemon
    {
        public Kogami() : base()
        {
            name = "Kogami";
            displayName = "Kogami Akira";
            MainColor = Color.HotPink;
            slogan = "はいい、これはあきらだぜ！！";
            commentsOnHit[0] = "W~Whyy?";
            commentsOnHit[1] = "痛って！！＞＜”";
            commentsOnHit[2] = "Is that it?! ";
            commentsOnHit[3] = ">< Ahh.." /*"Grr"*/;
            commentsOnHit[4] = "I'm a little girl, u know!?" /*"Grr"*/;

            commentsOnOther[0] = "No Way!";
            

            level = 50;
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Fairy;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
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
            clonedPokemon.item = null;
            return clonedPokemon;
        }
    }
}
