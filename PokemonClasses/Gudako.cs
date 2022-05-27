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
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Normal;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
