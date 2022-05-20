using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Braixen : Pokemon
    {
        public Braixen() : base()
        {
            name = "Braixen";
            displayName = "Braixen";
            MainColor = Color.LightGoldenrodYellow;

            level = 50;
            health = currHealth = 134;
            attack = currAttack = 79;
            defense = currDefense = 78;
            specialAttack = currSpecialAttack = 110;
            specialDefense = currSpecialDefense = 90;
            speed = currSpeed = 93;
            type1 = "Fire";
            type2 = "None";

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
