using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Pokemon_Simulator
{
    public abstract class Pokemon
    {
        public string name; // The internal name used for files
        public string displayName; // The name to be shown in the application
                                   //public
        public Color MainColor;
        public string slogan;

        public Font font;
        protected string[] comments = new string[5];


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

        protected string comment;


        Random rand = new Random();


        public Type type1 = Type.None;
        public Type type2 = Type.None;

        public List<Move> moves;

        public List<Move> knownMoves = new List<Move>();

        public List<Pokemon> knownPokemons = new List<Pokemon>();
        private Pokemon rivalPkmn;

        protected int[] MaxDamage = new int[4];

        public Move lastUsedMove;

        int moveCounter = 0;

        public StatusEffect currentStatusEffect = null;
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
        public  Pokemon GetRivalPokemon() { return  rivalPkmn; }
        public void SetRivalPokemon( Pokemon pkmn) { rivalPkmn = pkmn; }
        public string[] GetComment() { return comments; }

        public void SetStatusEffect(StatusEffect effect)
        {
            if(currentStatusEffect == null)
            {
                currentStatusEffect = effect;
            }
        }

        public void RemoveStatusEffect()
        {
            currentStatusEffect = null;
        }


        public virtual int ChangeStat(double stat,  double statToChange,  int statStage, int stageIncrease)
        {
            Console.WriteLine(stat + " " + statStage);
            if (statStage == 6) return 0;

            statStage += stageIncrease;
            if (statStage > 6) statStage = 6;

            if (statStage >= 0)
            {
                double modifier = statStage + 2;
                statToChange = stat * modifier / 2;
            }
            if (statStage < 0)
            {
                double modifier = -statStage + 2;
                statToChange = stat * 2 / modifier;
            }
            return statStage;
        }

        public virtual int ChangeAccuracyOrEvasion(double stat,  double statToChange,  int statStage, int stageIncrease)
        {
            if (statStage == 6) return 0;

            statStage += stageIncrease;
            if (statStage > 6) statStage = 6;

            if (statStage >= 0)
            {
                double modifier = statStage + 3;
                statToChange = stat * modifier / 3;
            }
            if (statStage < 0)
            {
                double modifier = -statStage + 3;
                statToChange = stat * 3 / modifier;
            }
            return statStage;
        }

        public virtual int UseMove( Move move,  Pokemon target)
        {

            double accuracyModifier = (move.accuracy / 100 * this.currAccuracy / 100 * target.currEvasion / 100);
            Random accuracyRand = new Random();
            if (accuracyModifier > accuracyRand.Next(1, 100))
            {
                return -1;
            }

            if (!move.actualAttack)
            {
                move.SpecialEffects(this);
                move.SpecialTargetEffects( target);
                return -2;
            }

            double levelModifier = (2 * level / 5) + 2;
            double defenseModifier = move.physical ? currAttack / target.currDefense : currSpecialAttack / target.currSpecialDefense;
            //Console.WriteLine(currAttack + "/" + target.currDefense + " " + currSpecialAttack + "/" + target.currSpecialDefense);
            Random rand = new Random();
            double randomModifier = (double)rand.Next(85, 100) / 100;
            double stabModifier = (type1 == move.type || type2 == move.type) ? 1.5 : 1;
            double typeModifier = TypeData.CalculateEffectiveness(move.type, target.type1) * TypeData.CalculateEffectiveness(move.type, target.type2);
            //Console.WriteLine(levelModifier + " " + defenseModifier + " " + stabModifier + " " + effectiveModifier);
            double damage = ((levelModifier * move.damage * defenseModifier / 50) + 2) * randomModifier * stabModifier * typeModifier;
            //Console.WriteLine();
            target.currHealth -= damage;

            if (move.recoil)
            {
                this.currHealth -= damage / 2;
            }

            // Return how much damage it did (as a percent compared to the target's total health)

            move.SpecialEffects(this);
            move.SpecialTargetEffects( target);

            return (int)damage;
        }
        public /*override*/ void AICPU(bool PlayerFirstw)
        {

            for (int h = 0; h < this.moves.Count; h++)
            {

                MaxDamage[h] = (int)moves[h].damage;
            }

            //rival losing,
            if (currHealth < health * 50 / 100 && !lastUsedMove.canHealOneSelf)
            {


                HealingMode();
            }
            else
            {
                if (rand.Next(0, 7) == 5)
                {
                    AttackPlus();
                }
                else
                {
                    AttackMode();
                }


            }

        }

        private void HealingMode()
        {
            for (int j = 0; j < this.moves.Count; j++)//Scan "Known", or used moves by player.
            {
                if (knownMoves[j].damage >= this.currHealth && (knownMoves[j].pp != 0))//If there's chance that *player* is gonna do an "one shot". Try ealing, protecting
                {
                    for (int i = 0; i < this.moves.Count; i++)// Scan own moves, looking for healng 
                    {


                        if (this.moves[i].canHealOneSelf && this.moves[i].pp != 0/* && rand.Next(0, 2) == 1 */&& !this.moves[i].actualAttack)
                        {
                            lastUsedMove = this.moves[i];
                            damage = this.UseMove( lastUsedMove,  rivalPkmn);
                            Console.WriteLine(name + " used " + moves[i].moveName + " dealing " + damage + " damage!");

                            return;
                        }
                        else
                        {

                            AttackMode();

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
                    if ((TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2 || (TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2) )&& this.moves[j].actualAttack)//Check if this attack can raise user's stats
                    {
                        lastUsedMove = this.moves[j];
                        damage = this.UseMove( lastUsedMove,  rivalPkmn);
                        Console.WriteLine(name + " used " + moves[j].moveName + " dealing " + damage + " damage!");

                        return;
                    }
                }
            }
            NoSupefectiveness();
        }
        private void AttackPlus()//
        {//-*Looking for an attack, or move that can heal, raise, etc
            for (int i = 0; i < this.moves.Count; i++)
            {


                if (this.moves[i].raisesAtk == true/*AbsobrsEnergy*/)
                {
                    lastUsedMove = this.moves[i];
                    damage = this.UseMove( lastUsedMove,  rivalPkmn);

                }
            }
        }

        private void NoSupefectiveness()
        {
            for (int j = 0; j < this.moves.Count; j++)
            {
                if (this.moves[j].damage == MaxDamage.Max())
                {

                    lastUsedMove = this.moves[j];
                    damage = this.UseMove( lastUsedMove,  rivalPkmn);


                }
            }
        }
        void CommnetModifier()
        {
            if (this.name.Equals("Dio"))
            {
                switch (rivalPkmn.displayName)
                {
                    case "Dio":
                        this.comments[0] = "Too tough to harm a little girl like me?!";

                        return;
                    case "Garou":

                        this.comments[0] = "This is what you train for?!";

                        return;



                }
            }


            if (this.name.Equals("Dio"))
            {
                switch (rivalPkmn.displayName)
                {
                    case "Gudako":
                        this.comments[0] = "As weak as you look.";

                        return;
                    case "Garou":

                        this.comments[0] = "Haha..";

                        return;



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
