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
            comments[2] = "How Come?!";
            comments[3] = "痛って！！＞＜”";
            

            level = 50;
            health = currHealth = 135;
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
    }
}
