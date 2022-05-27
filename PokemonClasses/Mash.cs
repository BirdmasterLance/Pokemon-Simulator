using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Mash : Pokemon
    {
        public Mash() : base()
        {
            name = "Mash";
            displayName = "Mash Kyrielight";
            MainColor = Color.Pink;

            level = 50;
            health = currHealth = 150*2;
            attack = currAttack = 95;
            defense = currDefense = 130;
            specialAttack = currSpecialAttack = 70;
            specialDefense = currSpecialDefense = 105;
            speed = currSpeed = 90;
            type1 = Type.Steel;

            moves.Add(new IronHead(this));
            moves.Add(new MeteorMash(this));
            moves.Add(new IronDefense(this));
            moves.Add(new Earthquake(this));
        }
    }
}
