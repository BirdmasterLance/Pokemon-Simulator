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
            health = currHealth = 125*2;
            attack = currAttack = 50;
            defense = currDefense = 80;
            specialAttack = currSpecialAttack = 120;
            specialDefense = currSpecialDefense = 95;
            speed = currSpeed = 80;
            type1 = Type.Fairy;        

            moves.Add(new DazzlingGleam(this));
            moves.Add(new HyperVoice(this));
            moves.Add(new Snarl(this));
            moves.Add(new QuiverDance(this));
        }
    }
}
