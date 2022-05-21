using System.Drawing;


namespace Pokemon_Simulator.PokemonClasses
{
    internal class Kasane : Pokemon
    {
        public Kasane() : base()
        {
            name = "Kasane";
            displayName = "Kasane Teto";
            MainColor = Color.Pink;

            level = 50;
            health = currHealth = 125;
            attack = currAttack = 58;
            defense = currDefense = 72;
            specialAttack = currSpecialAttack = 103;
            specialDefense = currSpecialDefense = 113;
            speed = currSpeed = 62;
            type1 = Type.Fairy;        

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
