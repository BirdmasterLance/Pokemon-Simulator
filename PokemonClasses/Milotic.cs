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
        }
    }
}
