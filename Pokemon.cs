using Pokemon_Simulator.Properties;
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

        protected string[] commentsOnHit = new string[5];
        protected string[] commentsOnOther = new string[5];
        protected string[]  commentsOnLowDmg = new string[5];


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

        public Item item;

        int moveCounter = 0;

        public StatusEffect currentStatusEffect = null; // According to Bulbepedia, this would be called a "Non-Volatile Status Effect"
        public HashSet<StatusEffect> currentVolatileStatusEffects = new HashSet<StatusEffect>();

        public Ability ability = null;

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
        public Pokemon GetRivalPokemon() { return rivalPkmn; }
        public void SetRivalPokemon(Pokemon pkmn) { rivalPkmn = pkmn; }
        public string[] GetComment() { return comments; }
        public string[] GetOnHitComment() { return commentsOnHit; }

        public string[] GetOnLowDmgHitComment() { return  commentsOnLowDmg; }

        public string[] GetOnOtherComment() { return commentsOnOther; }

        public virtual void HealPercent(double percent)
        {
            double healAmount = health * percent;
            currHealth += healAmount;
            if (currHealth > health)
            {
                currHealth = health;
            }
        }

        #region Status Effects

        /// <summary>
        /// Sets the current status effect. <br/>
        /// NOTE: A "Non Volatile" status effect refers to one such as burn, freeze, poison, etc.
        /// </summary>
        public void SetStatusEffect(StatusEffect effect)
        {
            if (currentStatusEffect == null)
            {
                if (effect.statusName == "Burn") currAttack /= 2;
                else if (effect.statusName == "Paralysis") currSpeed /= 2;

                currentStatusEffect = effect;
            }
        }

        public void RemoveStatusEffect()
        {
            if (currentStatusEffect.statusName == "Burn") currAttack *= 2;
            else if (currentStatusEffect.statusName == "Paralysis") currSpeed *= 2;

            currentStatusEffect = null;
        }

        public void AddVolatileStatusEffect(StatusEffect effect)
        {
            currentVolatileStatusEffects.Add(effect);
        }

        public void RemoveVolatileStatusEffect(string effect)
        {
            var effectToRemove = HasVolatileStatusEffect(effect);
            if (effectToRemove != null)
            {
                currentVolatileStatusEffects.Remove(effectToRemove);
            }
        }

        /// <summary>
        /// Check if a pokemon has a specific SubStatusEffect. Returns said effect if it exists.
        /// </summary>
        public StatusEffect HasVolatileStatusEffect(string effect)
        {
            foreach (StatusEffect currentStatusEffect in currentVolatileStatusEffects)
            {
                if (currentStatusEffect.statusName == effect)
                {
                    return currentStatusEffect;
                }
            }
            return null;
        }

        #endregion

        #region Stat Changes

        /// <summary>
        /// Handles raising or lowering stat calculation. <br/>
        /// stat: The stat to change (EX: GetAttack()) <br/>
        /// statToChange: The current version of the above stat (EX: currAttack) <br/>
        /// statStage: The current stage of the above stat (EX: attackStage) <br/>
        /// stageIncrease: The amount of stages to increase it by (EX: 1) <br/>
        /// </summary>
        public virtual int ChangeStat(double stat, ref double statToChange, ref int statStage, int stageIncrease)
        {
            if (statStage >= 6 || statStage <= -6) return statStage;

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

        public virtual int ChangeAccuracyOrEvasion(double stat, ref double statToChange, ref int statStage, int stageIncrease)
        {
            if (statStage >= 6 || statStage <= -6) return statStage;

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

        public virtual void ResetStatChanges()
        {
            currAttack = attack;
            currDefense = defense;
            currSpecialAttack = specialAttack;
            currSpecialDefense = specialDefense;
            currSpeed = speed;
            currAccuracy = accuracy;
            currEvasion = evasion;

            attackStage = defenseStage = specialAttackStage = specialDefenseStage = speedStage = accuracyStage = evasionStage = 0;
        }

        #endregion

        #region Damage and Moves

        private bool debugMove = true;
        public virtual double GetDamage(Move move, Pokemon target)
        {
            double levelModifier = (2 * level / 5) + 2;
            double defenseModifier = move.physical ? currAttack / target.currDefense : currSpecialAttack / target.currSpecialDefense;

            Random rand = new Random();
            double randomModifier = (double)rand.Next(85, 100) / 100;
            double stabModifier = (type1 == move.type || type2 == move.type) ? 1.5 : 1;
            double typeModifier = TypeData.CalculateEffectiveness(move.type, target.type1) * TypeData.CalculateEffectiveness(move.type, target.type2);

            // Raise the hit event by super effective move
            if (typeModifier > 1) BattleEventHandler.instance.OnHitBySuperEffective(target);

            double criticalModifier = 1;
            if(move.criticalHitChance >= rand.NextDouble())
            {
                criticalModifier = 1.5f;
                defenseModifier = move.physical ? currAttack / target.defense : currSpecialAttack / target.specialDefense;
                //BattleEventHandler.instance.HitByCritical(target); // Raise the event if hit by critical
            }

            double weatherModifier = 1;
            if (move.type == Type.Fire && BattleData.currentWeather?.weatherName == "Rain") weatherModifier = 0.5;
            if (move.type == Type.Fire && BattleData.currentWeather?.weatherName == "Sunlight") weatherModifier = 1.5;
            if (move.type == Type.Water && BattleData.currentWeather?.weatherName == "Sunlight") weatherModifier = 0.5;
            if (move.type == Type.Water && BattleData.currentWeather?.weatherName == "Rain") weatherModifier = 1.5;

            if(debugMove) Console.Write($"{move.moveName} data: " +
                $"\n  Base Damage: {move.damage}" +
                $"\n  Level Modifier: {levelModifier}" +
                $"\n  Defense Modifier (Physical Move? {move.physical}): " +
                $"\n    If physical: Current Attack ({currAttack}) / Target's Defense ({target.currDefense})" +
                $"\n    If special: Current Sp. Attack ({currSpecialAttack}) / Target's Sp. Defense ({target.currSpecialDefense})" +
                $"\n    = {defenseModifier}" +
                $"\n  (levelModifier * baseDamage * defenseModifier / 50) + 2 = {(levelModifier * move.damage * defenseModifier / 50) + 2}" +
                $"\n  Random Modifier: x{randomModifier}" +
                $"\n  Stab Modifier: x{stabModifier}" +
                $"\n  Super Effective Modifier: x{typeModifier}" +
                $"\n  Critical Modifier: x{criticalModifier}" +
                $"\n  Weather Modifier: x{weatherModifier}" +
                $"\nDamage before reductions/boosts to final damage: ");

            return ((levelModifier * move.damage * defenseModifier / 50) + 2)
                * weatherModifier * criticalModifier * randomModifier * stabModifier * typeModifier;
        }

        public virtual int UseMove(Move move, Pokemon target)
        {
            double accuracyModifier = (move.accuracy / 100 * this.currAccuracy / 100 * target.currEvasion / 100);
            Random accuracyRand = new Random();
            if (accuracyModifier > accuracyRand.Next(1, 100))
            {
                return -1; // Return -1 if we miss
            }

            move.pp--;

            if (!move.actualAttack)
            {
                move.SpecialEffects();
                move.SpecialTargetEffects(target);
                return -2; // Return -2 if this didn't actually attack
            }
            
            double damage = GetDamage(move, target);

            if (debugMove) Console.WriteLine($"{damage}");

            if (item != null && item.itemName == "Life Orb")
            {
                damage *= 1.3;
                currHealth -= health / 10;
                if (debugMove) Console.WriteLine($"  Damage boosted by Life Orb (1.3x): {damage}");
            }

            if (((target.Equals(BattleWindow.instance.activeEnemyPokemon) && BattleData.HasSubWeather(ref BattleData.enemySubWeather, "Reflect") != null)
                || (target.Equals(BattleWindow.instance.activePokemon) && BattleData.HasSubWeather(ref BattleData.playerSubWeather, "Reflect") != null)) && move.physical)
            {
                damage /= 2;
                if (debugMove) Console.WriteLine($"  Damage reduced by Reflect (by 1/2): {damage}");
            }
            if (((target.Equals(BattleWindow.instance.activeEnemyPokemon) && BattleData.HasSubWeather(ref BattleData.enemySubWeather, "Light Screen") != null)
                || (target.Equals(BattleWindow.instance.activePokemon) && BattleData.HasSubWeather(ref BattleData.playerSubWeather, "Light Screen") != null)) && !move.physical)
            {
                damage /= 2;
                if (debugMove) Console.WriteLine($"  Damage reduced by Light Screen (by 1/2): {damage}");
            }
            if ((target.Equals(BattleWindow.instance.activeEnemyPokemon) && BattleData.HasSubWeather(ref BattleData.enemySubWeather, "Aurora Veil") != null)
                || (target.Equals(BattleWindow.instance.activePokemon) && BattleData.HasSubWeather(ref BattleData.playerSubWeather, "Aurora Veil") != null))
            {
                damage /= 2;
                if (debugMove) Console.WriteLine($"  Damage reduced by Aurora Veil (by 1/2): {damage}");
            }


            target.currHealth -= damage;

            if (move.recoil)
            {
                currHealth -= damage / 2;
                if (debugMove) Console.WriteLine($"  Damage taken by recoil (by 1/2): {damage/2}");
            }

            move.SpecialEffects();
            move.SpecialTargetEffects(target);

            // TODO: different moves have different info that needs to be passed into the battle window, do something about it
            return (int)damage;
        }

        #endregion

        public /*override*/ Move AICPU(bool PlayerFirstw)
        {

            for (int h = 0; h < this.moves.Count; h++)
            {

                MaxDamage[h] = (int)moves[h].damage;
            }

            //rival losing,
            if (currHealth < health * 50 / 100/* && !lastUsedMove.canHealOneSelf*/)
            {


                return HealingMode();
            }
            else
            {
                if (rand.Next(0, 7) == 5)
                {
                    return AttackPlus();
                }
                else
                {
                    return AttackMode();
                }


            }

        }

        private Move HealingMode()
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
                            //damage = this.UseMove(lastUsedMove, rivalPkmn);
                            Console.WriteLine(name + " used " + moves[i].moveName + " dealing " + damage + " damage!");

                            return lastUsedMove;
                        }
                        else
                        {

                            return AttackMode();
                        }
                        //else if (moves[i] /*.protects*/)
                        //{


                        //}
                    }
                }
            }
            return AttackMode();
        }
        private Move AttackMode()
        {


            //knownMoves.Add(move);

            //knownPokemons.Add(pkmn);
            for (int f = 0; f < knownPokemons.Count; f++)
            {
                for (int j = 0; j < this.moves.Count; j++)
                {
                    if ((TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2 || (TypeData.CalculateEffectiveness(this.moves[j].type, rivalPkmn.type1) == 2)) && this.moves[j].actualAttack)//Check if this attack can raise user's stats
                    {
                        lastUsedMove = this.moves[j];
                        //damage = this.UseMove(lastUsedMove, rivalPkmn);
                        Console.WriteLine(name + " used " + moves[j].moveName + " dealing " + damage + " damage!");

                        return lastUsedMove;
                    }
                }
            }
            return NoSupefectiveness();
        }
        private Move AttackPlus()//
        {//-*Looking for an attack, or move that can heal, raise, etc
            for (int i = 0; i < this.moves.Count; i++)
            {


                if (this.moves[i].raisesAtk == true/*AbsobrsEnergy*/)
                {
                    lastUsedMove = this.moves[i];
                    //damage = this.UseMove(lastUsedMove, rivalPkmn);
                    return lastUsedMove;
                }
            }
            return null;
        }

        private Move NoSupefectiveness()
        {
            for (int j = 0; j < this.moves.Count; j++)
            {
                if (this.moves[j].damage == MaxDamage.Max())
                {

                    lastUsedMove = this.moves[j];
                    //damage = this.UseMove(lastUsedMove, rivalPkmn);
                    return lastUsedMove;

                }
            }
            return lastUsedMove;
        }
        void CommentModifier()
        {
            if (this.name.Equals("Kogami"))
            {
                switch (rivalPkmn.displayName)
                {
                    case "Dio":
                        commentsOnHit[0] = "Too tough to harm a little girl like me?!";

                        return;
                    case "Garou":

                        commentsOnHit[0] = "This is what you train for?!";

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

        public abstract object Clone();
        public override string ToString()
        {
            return displayName;
        }
    }
}
