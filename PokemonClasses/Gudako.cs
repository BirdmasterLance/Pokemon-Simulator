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
        }
    }
}
