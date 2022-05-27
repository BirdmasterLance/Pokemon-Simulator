using System.Drawing;

namespace Pokemon_Simulator.PokemonClasses
{
    class Dio : Pokemon
    {
        public Dio() : base()
        {
            name = "Dio";
            displayName = "DIO";
            MainColor = Color.Gold;
            slogan = "How many slices of bread?";
            font = new Font("Arial",10);

            comments[0] = "Is that it?";
            comments[1] = "Muda!";
            comments[4] = "Kono Dio Da!";

            level = 50;
            health = currHealth = 135*2;
            attack = currAttack = 90;
            defense = currDefense = 85;
            specialAttack = currSpecialAttack = 145;
            specialDefense = currSpecialDefense = 125;
            speed = currSpeed = 110;
            type1 = Type.Dark;

            moves.Add(new DazzlingGleam(this));
            moves.Add(new MysticalFire(this));
            moves.Add(new Recover(this));
            moves.Add(new CalmMind(this));
        }
    }
}
