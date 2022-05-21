using System.Collections.Generic;
using System.Drawing;

namespace Pokemon_Simulator
{
    internal abstract class Pokemon
    {
        public string name; // The internal name used for files
        public string displayName; // The name to be shown in the application
                                   //public
        public Color MainColor;
        public string slogan;


        public int level;

        protected double health;
        public double currHealth;

        protected double attack;
        public double currAttack;

        protected double defense;
        public double currDefense;

        protected double specialAttack;
        public double currSpecialAttack;

        protected double specialDefense;
        public double currSpecialDefense;

        protected double speed;
        public double currSpeed;

        public Type type1 = Type.None;
        public Type type2 = Type.None;

        public List<Move> moves;

        public List<Move> knownMoves = new List<Move>();

        public List<Pokemon> knownPokemons = new List<Pokemon>();

        // TODO: Held Item

        protected Pokemon()
        {
            moves = new List<Move>();
        }

        public double GetHealth() { return health; }
        public double GetAttack() { return attack; }
        public double GetDefense() { return defense; }
        public double GetSpecialAttack() { return specialAttack; }
        public double GetSpecialDefense() { return specialDefense; }
        public double GetSpeed() { return speed; }

        public virtual int UseMove(Move move, Pokemon target)
        {
            if (!move.actualAttack)
            {
                move.SpecialEffects();
                return -1;
            }

            move.SpecialEffects();
            move.SpecialTargetEffects(target);

            double levelModifier = (2 * level / 5) + 2;
            double defenseModifier = move.physical ? currAttack / target.currDefense : currSpecialAttack / target.currSpecialDefense;
            double stabModifier = (type1 == move.type || type2 == move.type) ? 1.5 : 1;
            // TODO: supereffective and not very effective
            double effectiveModifier = TypeData.CalculateEffectiveness(type1, move.type) * TypeData.CalculateEffectiveness(type2, move.type);

            double damage = ((levelModifier * move.damage * defenseModifier / 50) + 2) * stabModifier * effectiveModifier;

            target.currHealth -= damage;

            if (move.recoil)
            {
                this.currHealth -= damage / 2;
            }

            // Return how much damage it did (as a percent compared to the target's total health)
            return (int)damage;
        }
        public /*override*/ void AICPU(bool PlayerFirstw)
        {

            //knownMoves.Add(move);

            //knownPokemons.Add(pkmn);
            //rival losing,
            if (PlayerFirstw)
            {
                for (int j = 0; j < this.moves.Count; j++)
                {
                    if (knownMoves[j].damage >= this.currHealth)
                    {
                        for (int i = 0; i < this.moves.Count; i++)
                        {

                            if (this.moves[i].canHealOneSelf)
                            {
                                this.UseMove(this.moves[i], this);

                            }
                            //else if (moves[i] /*.protects*/)
                            //{


                            //}
                        }
                    }
                }
            }

        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            return displayName;
        }
    }
}
