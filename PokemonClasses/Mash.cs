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
            health = currHealth = 125;
            attack = currAttack = 58;
            defense = currDefense = 72;
            specialAttack = currSpecialAttack = 103;
            specialDefense = currSpecialDefense = 113;
            speed = currSpeed = 62;
            type1 = "Steel";
            type2 = "None";

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
