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
            BattleEventHandler.instance.OnEndTurn += EndTurnEffect;
            BattleEventHandler.instance.OnPokemonSwitchIn += SwitchInEffect;
            BattleEventHandler.instance.OnPokemonSwitchOut += SwitchOutEffect;

            GCHandle objHandle = GCHandle.Alloc(pokemon, GCHandleType.WeakTrackResurrection);
            int address = GCHandle.ToIntPtr(objHandle).ToInt32();
            Console.WriteLine(address);

            GCHandle objHandle2 = GCHandle.Alloc(affectedPkmn, GCHandleType.WeakTrackResurrection);
            int address2 = GCHandle.ToIntPtr(objHandle2).ToInt32();
            Console.WriteLine(address2);
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

        public BurnStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn) 
        {
            statusName = "Burn";
            color = Color.FromArgb(242, 127, 48);
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() / 16;
        }
    }

    class ParalysisStatusEffect : StatusEffect
    {
        public ParalysisStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Paralysis";
            color = Color.FromArgb(249, 208, 49);
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
        public FreezeStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Frozen";
            color = Color.FromArgb(155, 214, 218);
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

        public PoisonStatusEffect(Pokemon affectedPkmn) : base(affectedPkmn)
        {
            statusName = "Poison";
            color = Color.FromArgb(161, 64, 166);
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() / 8;
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
            Console.WriteLine(affectedPkmn.displayName + " now has " + statusName);
        }

        protected override void SwitchOutEffect(object sender, Pokemon pkmn)
        {
            numTurnsElasped = 1;
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            pokemon.currHealth -= pokemon.GetHealth() * (numTurnsElasped / 16);
            numTurnsElasped++;
            Console.WriteLine(pokemon.displayName + " now has " + pokemon.currHealth + " health");
        }
    }
}
