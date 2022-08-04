using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Pokemon_Simulator
{
    public abstract class StatusEffect
    {
        public string statusName;
        protected Pokemon pokemon;
        protected Color color;

        public StatusEffect(Pokemon affectedPkmn)
        {
            pokemon = affectedPkmn;
            BattleEventHandler.instance.GameStateChange += EndTurnEffect;
            BattleEventHandler.instance.PokemonSwitchIn += SwitchInEffect;
            BattleEventHandler.instance.PokemonSwitchOut += SwitchOutEffect;
        }

        /// <summary>
        /// What happens when the pokemon switches in
        /// </summary>
        protected virtual void SwitchInEffect(Pokemon pkmn) { }

        /// <summary>
        /// What happens when the pokemon switches out
        /// </summary>
        protected virtual void SwitchOutEffect(Pokemon pkmn) { }

        /// <summary>
        /// What does this effect do at every turn?
        /// </summary>
        protected virtual void EndTurnEffect(Properties.GameState state) { }

        /// <summary>
        /// What happens when the user tries to do an action
        /// </summary>
        public virtual bool Effect() { return false; }

        public Color GetColor() { return color; }

        public bool Equals(StatusEffect obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            if (object.ReferenceEquals(obj, this)) return true;
            return obj.statusName == statusName;
        }
    }

    class BurnStatusEffect : StatusEffect
    {

        public BurnStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn) 
        {
            statusName = "Burn";
            color = Color.FromArgb(242, 127, 48);
        }

        protected override void SwitchInEffect(Pokemon pkmn)
        {
            pokemon.currAttack /= 2;
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if(state == Properties.GameState.EndTurn) pokemon.currHealth -= pokemon.GetHealth() / 16;
        }
    }

    class ParalysisStatusEffect : StatusEffect
    {
        public ParalysisStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Paralysis";
            color = Color.FromArgb(249, 208, 49);
        }

        protected override void SwitchInEffect(Pokemon pkmn)
        {
            pokemon.currSpeed /= 2;
        }

        public override bool Effect()
        {
            Random rand = new Random();
            if(rand.NextDouble() <= 0.25)
            {
                return true;
            }
            return false;
        }
    }

    class FreezeStatusEffect : StatusEffect
    {
        public FreezeStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Frozen";
            color = Color.FromArgb(155, 214, 218);
        }

        public override bool Effect()
        {
            Random rand = new Random();
            if (rand.NextDouble() <= 0.20)
            {
                pokemon.RemoveStatusEffect();
                return false;
            }
            return true;
        }
    }

    class SleepStatusEffect : StatusEffect
    {
        private int numTurnsElasped;
        private int turnDuration;

        public SleepStatusEffect(Pokemon affectedPkmn, int duration = 0) : base(affectedPkmn)
        {
            statusName = "Asleep";
            color = Color.FromArgb(142, 136, 140);
            if(duration == 0)
            {
                Random rand = new Random();
                turnDuration = rand.Next(1, 4);
            }
            else
            {
                turnDuration = duration;
            }
        }

        public override bool Effect()
        {
            if(numTurnsElasped == turnDuration)
            {
                pokemon.currentStatusEffect = null;
                return false;
            }
            return true;
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if (state == Properties.GameState.EndTurn) numTurnsElasped++;
        }
    }

    class PoisonStatusEffect : StatusEffect
    {

        public PoisonStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Poison";
            color = Color.FromArgb(161, 64, 166);
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if (state == Properties.GameState.EndTurn) pokemon.currHealth -= pokemon.GetHealth() / 8;
        }
    }

    class ToxicStatusEffect : StatusEffect
    {

        private int numTurnsElasped;

        public ToxicStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Badly Psn";
            numTurnsElasped = 1;
            color = Color.FromArgb(161, 64, 166);
        }

        protected override void SwitchOutEffect(Pokemon pkmn)
        {
            numTurnsElasped = 1;
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if (state == Properties.GameState.EndTurn)
            {
                pokemon.currHealth -= pokemon.GetHealth() * ((double)numTurnsElasped / 16);
                numTurnsElasped++;
            }
        }
    }

    class ConfusedStatusEffect : StatusEffect
    {

        private int numTurnsElasped;
        private int turnDuration;

        public ConfusedStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Confused";
            numTurnsElasped = 1;
            Random rand = new Random();
            turnDuration = rand.Next(2, 5);
        }

        public override bool Effect()
        {
            if (numTurnsElasped == turnDuration)
            {
                pokemon.RemoveSubStatusEffect("Confused");
                return false;
            }
            return true;
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if (state == Properties.GameState.EndTurn) numTurnsElasped++;
        }
    }

    class OutrageStatusEffect : StatusEffect
    {

        private int numTurnsElasped;
        private int turnDuration;

        public OutrageStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Outrage";
            numTurnsElasped = 1;
            Random rand = new Random();
            turnDuration = rand.Next(2, 3);
        }

        public override bool Effect()
        {
            if (numTurnsElasped == turnDuration)
            {
                pokemon.RemoveSubStatusEffect("Outrage");
                pokemon.AddSubStatusEffect(new ConfusedStatusEffect(pokemon));
                return false;
            }
            return true;
        }

        protected override void EndTurnEffect(Properties.GameState state)
        {
            if (state == Properties.GameState.EndTurn) numTurnsElasped++;
        }
    }
}
