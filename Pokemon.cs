using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
        public int attackStage;

        protected double defense;
        public double currDefense;
        public int defenseStage;

        protected double specialAttack;
        public double currSpecialAttack;
        public int specialAttackStage;

        protected double specialDefense;
        public double currSpecialDefense;
        public int specialDefenseStage;

        protected double speed;
        public double currSpeed;
        public int speedStage;

        protected double accuracy;
        public double currAccuracy;
        public int accuracyStage;

        protected double evasion;
        public double currEvasion;
        public int evasionStage;

        protected int damage;


        Random rand = new Random();


        public Type type1 = Type.None;
        public Type type2 = Type.None;

        public List<Move> moves;

        public List<Move> knownMoves = new List<Move>();

        public List<Pokemon> knownPokemons = new List<Pokemon>();
        private Pokemon rivalPkmn;

        protected int[] MaxDamage = new int[4];

        public Move lastUsedMove;
        // TODO: Held Item

        protected Pokemon()
        {
            attackStage = defenseStage = specialAttackStage = specialDefenseStage = speedStage = 0;
            accuracy = currAccuracy = 100;
            evasion = currEvasion = 1; // idk wat to put here lol
            moves = new List<Move>();
        }

        public double GetHealth() { return health; }
        public double GetAttack() { return attack; }
        public double GetDefense() { return defense; }
        public double GetSpecialAttack() { return specialAttack; }
        public double GetSpecialDefense() { return specialDefense; }
        public double GetSpeed() { return speed; }
        public double GetDamage() { return damage; }
        public ref Pokemon GetRivalPokemon() { return ref rivalPkmn; }
        public void SetRivalPokemon(ref Pokemon pkmn) { rivalPkmn = pkmn; }

        public virtual int ChangeStat(ref double stat, ref int statStage, int stageIncrease)
        {
            Console.WriteLine(stat + " " + statStage);
            if (statStage == 6) return 0;

            statStage += stageIncrease;
            if (statStage > 6) statStage = 6;

            if (statStage >= 0)
            {
                double modifier = statStage + 2;
                stat *= modifier / 2;
            }
            if (statStage < 0)
            {
                double modifier = -statStage + 2;
                stat *= 2 / modifier;
            }
            Console.WriteLine(stat + " " + statStage);
            return statStage;
        }

        public virtual int ChangeAccuracyOrEvasion(ref double stat, ref int statStage, int stageIncrease)
        {
            if (statStage == 6) return 0;

            statStage += stageIncrease;
            if (statStage > 6) statStage = 6;

            if (statStage >= 0)
            {
                double modifier = statStage + 3;
                stat *= modifier / 3;
            }
            if (statStage < 0)
            {
                double modifier = -statStage + 3;
                stat *= 3 / modifier;
            }
            return statStage;
        }

        public virtual int UseMove(Move move, ref Pokemon target)
        {

            double accuracyModifier = (move.accuracy / 100 * this.currAccuracy / 100 * target.currEvasion / 100);
            Random accuracyRand = new Random();
            if (accuracyModifier > accuracyRand.Next(1, 100))
            {
                return -1;
            }

            if (!move.actualAttack)
            {
                move.SpecialEffects();
                move.SpecialTargetEffects(ref target);
                return -2;
            }

            double levelModifier = (2 * level / 5) + 2;
            double defenseModifier = move.physical ? currAttack / target.currDefense : currSpecialAttack / target.currSpecialDefense;
            //Console.WriteLine(currAttack + "/" + target.currDefense + " " + currSpecialAttack + "/" + target.currSpecialDefense);
            double stabModifier = (type1 == move.type || type2 == move.type) ? 1.5 : 1;
            double effectiveModifier = TypeData.CalculateEffectiveness(move.type, target.type1) * TypeData.CalculateEffectiveness(move.type, target.type2);
            //Console.WriteLine(levelModifier + " " + defenseModifier + " " + stabModifier + " " + effectiveModifier);
            double damage = ((levelModifier * move.damage * defenseModifier / 50) + 2) * stabModifier * effectiveModifier;
            //Console.WriteLine();
            target.currHealth -= damage;

            if (move.recoil)
            {
                this.currHealth -= damage / 2;
            }

            // Return how much damage it did (as a percent compared to the target's total health)

            move.SpecialEffects();
            move.SpecialTargetEffects(ref target);

            return (int)damage;
        }
        public /*override*/ void AICPU(bool PlayerFirstw)
        {


            for (int h = 0; h < this.moves.Count; h++)
            {

                MaxDamage[h] = (int)moves[h].damage;
            }

            //rival losing,
            if (currHealth < health * 50 / 100)
            {

                HealingMode();
            }
            else
            {


                AttackMode();
                if (rand.Next(0, 7) == 5)
                {
                    AttackPlus();
                }

            }

        }

        private void HealingMode()
        {
            for (int j = 0; j < this.moves.Count; j++)
            {
                if (moves[j].damage >= this.currHealth)
                {
                    for (int i = 0; i < this.moves.Count; i++)
                    {

                        if (this.moves[i].canHealOneSelf)
                        {
                            lastUsedMove = this.moves[i];
                            damage = this.UseMove(this.moves[i], ref rivalPkmn);
                            return;
                        }
                        //else if (moves[i] /*.protects*/)
                        //{


                        //}
                    }
                }
            }
            AttackMode();
        }
        private void AttackMode()
        {


            //knownMoves.Add(move);

            //knownPokemons.Add(pkmn);
            for (int f = 0; f < knownPokemons.Count; f++)
            {
                for (int j = 0; j < this.moves.Count; j++)
                {
                    if (TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2 || (TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2))//Check if this attack can raise user's stats
                    {
                        lastUsedMove = this.moves[j];
                        damage = this.UseMove(this.moves[j], ref rivalPkmn);
                        return;
                    }
                }
            }
            NoSuperEffectiveness();
        }
        private void AttackPlus()
        {
            for (int i = 0; i < this.moves.Count; i++)
            {


                if (this.moves[i].raisesAtk == true/*AbsobrsEnergy*/)
                {
                    lastUsedMove = this.moves[i];
                    damage = this.UseMove(this.moves[i], ref rivalPkmn);

                }
            }
        }

        private void NoSuperEffectiveness()
        {
            for (int j = 0; j < this.moves.Count; j++)
            {
                if (this.moves[j].damage == MaxDamage.Max())
                {
                    //for (int i = 0; i < this.moves.Count; i++)
                    //{

                    //if (this.moves[i]./*AbsobrsEnergy*/)
                    //{
                    //    damage = this.UseMove(this.moves[i], this);

                    //}
                    lastUsedMove = this.moves[j];
                    damage = this.UseMove(this.moves[j], ref rivalPkmn);

                    //}
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
