using System;
using System.Drawing;

namespace Pokemon_Simulator
{
    public abstract class StatusEffect
    {
        protected BattleEventHandler battleEventHandler;
        protected Pokemon pokemon;
        protected Color color;

        public StatusEffect(Pokemon affectedPkmn)
        {
            pokemon = affectedPkmn;
            battleEventHandler = new BattleEventHandler();
            battleEventHandler.OnEndTurn += EndTurnEffect;
            battleEventHandler.OnPokemonSwitchIn += SwitchInEffect;
            battleEventHandler.OnPokemonSwitchOut += SwitchOutEffect;
        }

        /// <summary>
        /// What happens when the pokemon switches in
        /// </summary>
        protected virtual void SwitchInEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What happens when the pokemon switches out
        /// </summary>
        protected virtual void SwitchOutEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What does this effect do at every turn?
        /// </summary>
        protected virtual void EndTurnEffect(object sender, EventArgs e) { }

        /// <summary>
        /// What happens when the user tries to do an action
        /// </summary>
        protected virtual bool Effect() { return true; }

        public Color GetColor() { return color; }
    }

    class BurnStatusEffect : StatusEffect
    {

        public BurnStatusEffect(ref Pokemon affectedPkmn) : base(affectedPkmn) 
        {
            color = Color.FromArgb(239, 152, 70);
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() / 16;
        }
    }

    class ParalysisStatusEffect : StatusEffect
    {
        public ParalysisStatusEffect(ref Pokemon affectedPkmn) : base(affectedPkmn)
        {
            color = Color.FromArgb(239, 152, 70);
        }

        protected override void SwitchInEffect(object sender, Pokemon pkmn)
        {
            pkmn.currSpeed = pkmn.GetSpeed() / 2;
        }

        protected override bool Effect()
        {
            Random rand = new Random();
            if(rand.NextDouble() <= 0.25)
            {
                return false;
            }
            return true;
        }
    }

    class FreezeStatusEffect : StatusEffect
    {
        public FreezeStatusEffect(ref Pokemon affectedPkmn) : base(affectedPkmn)
        {
            color = Color.FromArgb(239, 152, 70);
        }

        protected override bool Effect()
        {
            Random rand = new Random();
            if (rand.NextDouble() <= 0.20)
            {
                pokemon.currentStatusEffect = null;
                return true;
            }
            return false;
        }
    }

    class SleepStatusEffect : StatusEffect
    {
        private int numTurnsElasped;
        private int turnDuration;

        public SleepStatusEffect(ref Pokemon affectedPkmn, int duration = 0) : base(affectedPkmn)
        {
            color = Color.FromArgb(239, 152, 70);
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

        protected override bool Effect()
        {
            if(numTurnsElasped == turnDuration)
            {
                pokemon.currentStatusEffect = null;
                return true;
            }
            return false;
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            numTurnsElasped++;
        }
    }

    class PoisonStatusEffect : StatusEffect
    {

        public PoisonStatusEffect(ref Pokemon affectedPkmn) : base(affectedPkmn)
        {
            color = Color.FromArgb(239, 152, 70);
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() / 8;
        }
    }

    class ToxicStatusEffect : StatusEffect
    {

        private int numTurnsElasped;

        public ToxicStatusEffect(ref Pokemon affectedPkmn) : base(affectedPkmn)
        {
            numTurnsElasped = 1;
            color = Color.FromArgb(239, 152, 70);
        }

        protected override void SwitchOutEffect(object sender, Pokemon pkmn)
        {
            numTurnsElasped = 1;
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() * (numTurnsElasped / 16);
            numTurnsElasped++;
        }
    }
}
