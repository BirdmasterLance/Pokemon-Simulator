using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Miku : Pokemon
    {
        public Miku() : base()
        {
            name = "Miku";
            displayName = "Hatsune Miku";
            MainColor = Color.Aquamarine;

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
    }
}
