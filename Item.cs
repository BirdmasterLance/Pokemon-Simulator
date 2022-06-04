

using System;

namespace Pokemon_Simulator
{
    public abstract class Item
    {
        public string itemName;
        protected Pokemon holder;

        public Item(Pokemon holder)
        {
            this.holder = holder;
            BattleEventHandler.instance.OnEndTurn += EndTurnEffect;
            BattleEventHandler.instance.OnPokemonSwitchIn += SwitchInEffect;
            BattleEventHandler.instance.OnPokemonSwitchOut += SwitchOutEffect;
            BattleEventHandler.instance.OnPokemonFainted += PokemonFaintedEffect;
            BattleEventHandler.instance.OnUseAttack += UseAttackEffect;
            BattleEventHandler.instance.OnHitByMove += HitByMoveEffect;
            BattleEventHandler.instance.OnHitBySuperEffective += HitBySuperEffectiveEffect;
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
        /// What does this item do at every turn?
        /// </summary>
        protected virtual void EndTurnEffect(object sender, EventArgs e) { }

        /// <summary>
        /// What does the item do when the pokemon faints?
        /// </summary>
        protected virtual void PokemonFaintedEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What does the item do after the player uses an attack?
        /// </summary>
        protected virtual void UseAttackEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What does the item do when the player is hit by any attack?
        /// </summary>
        protected virtual void HitByMoveEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What does the item do when the player is hit by a super effective attack?
        /// </summary>
        protected virtual void HitBySuperEffectiveEffect(object sender, Pokemon pkmn) { }

        /// <summary>
        /// What happens when the user tries to do an action
        /// </summary>
        protected virtual bool Effect() { return true; }
    }

    public class LifeOrb : Item
    {
        public LifeOrb(Pokemon holder) : base(holder) { }


    }

    public class ChoiceScarf : Item
    {
        public ChoiceScarf(Pokemon holder) : base(holder) { }

        protected override void SwitchInEffect(object sender, Pokemon pkmn) 
        {
            holder.currSpeed *= 1.5;
        }
    }

    public class Leftovers : Item
    {
        public Leftovers(Pokemon holder) : base(holder) { }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            holder.HealPercent(0.0625);
        }
    }
}
