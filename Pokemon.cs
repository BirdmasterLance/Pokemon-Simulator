using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    internal abstract class Pokemon
    {
        public string name; // The internal name used for files
        public string displayName; // The name to be shown in the application
        public int level;

        public double health;
        public double currHealth;

        protected double attack;
        public double currAttack;

        public double currDefense;
        protected double defense;

        public double currSpecialAttack;
        protected double specialAttack;

        protected double specialDefense;
        public double currSpecialDefense;

        public double currSpeed;
        protected double speed;

        public string type1;
        public string type2;

        public List<Move> moves;

        // For the main menu
        public string slogan;

        public Pokemon()
        {
            currHealth = health;
            currDefense = defense;
            currAttack = attack;
            currSpecialAttack = specialAttack;
            currSpeed = speed;
            moves = new List<Move>();
        }

        public virtual int UseMove(Move move, Pokemon target)
        {
            if(!move.actualAttack)
            {
                move.SpecialEffects();
                return -1;
            }

            move.SpecialEffects();
            move.SpecialTargetEffects(target);

            double levelModifier = (2 * level / 5) + 2;
            double defenseModifier = move.physical ? attack / target.defense : specialAttack / target.specialDefense;
            double stabModifier = (type1 == move.type || type2 == move.type) ? 1.5 : 1;
            // TODO: supereffective and not very effective

            double damage = ((levelModifier * move.damage * defenseModifier / 50) + 2) * stabModifier;

            target.currHealth -= damage;
            
            if(move.recoil)
            {
                this.currHealth -= damage / 2;
            }

            // Return how much damage it did (as a percent compared to the target's total health)
            return (int) damage;
        }

        public override string ToString()
        {
            return displayName;
        }
    }
}
