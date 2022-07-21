

using System;

namespace Pokemon_Simulator
{
    public abstract class Item
    {
        public string itemName;
        public string description;
        protected Pokemon holder;

        public Item()
        {
            BattleEventHandler.instance.EndTurn += EndTurnEffect;
            BattleEventHandler.instance.PokemonSwitchIn += SwitchInEffect;
            BattleEventHandler.instance.PokemonSwitchOut += SwitchOutEffect;
            BattleEventHandler.instance.PokemonFainted += PokemonFaintedEffect;
            BattleEventHandler.instance.UseAttack += UseAttackEffect;
            BattleEventHandler.instance.HitByMove += HitByMoveEffect;
            BattleEventHandler.instance.HitBySuperEffective += HitBySuperEffectiveEffect;
        }

        /// <summary>
        /// Sets the holder of this item
        /// </summary>
        public void SetHolder(Pokemon holder)
        {
            this.holder = holder;
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

        public override string ToString()
        {
            return itemName;
        }
    }

    public class LifeOrb : Item
    {
        public LifeOrb()
        {
            itemName = "Life Orb";
            description = "Boost the power of the user's attacks by 30% at the cost of 10% HP after an attack is used";
        }
    }

    public class ChoiceScarf : Item
    {
        public ChoiceScarf() 
        {
            itemName = "Choice Scarf";
            description = "Boosts the user's speed by 50%, but the user can only use the first move selected";
        }

        protected override void SwitchInEffect(object sender, Pokemon pkmn) 
        {
            // Because of how items were written, copies of items from the ItemWindow exist and do things, despite not being in the battle
            if(holder != null) pkmn.currSpeed *= 1.5;
        }
    }

    public class ChoiceBand : Item
    {
        public ChoiceBand()
        {
            itemName = "Choice Band";
            description = "Boosts the user's attack by 50%, but the user can only use the first move selected";
        }

        protected override void SwitchInEffect(object sender, Pokemon pkmn)
        {         
            if (holder != null) pkmn.currAttack *= 1.5;
        }
    }

    public class ChoiceSpecs : Item
    {
        public ChoiceSpecs()
        {
            itemName = "Choice Specs";
            description = "Boosts the user's special attack by 50%, but the user can only use the first move selected";
        }

        protected override void SwitchInEffect(object sender, Pokemon pkmn)
        {
            if (holder != null) pkmn.currSpecialAttack *= 1.5;
        }
    }

    public class Leftovers : Item
    {
        public Leftovers()
        {
            itemName = "Leftovers";
            description = "Restores 1/16th of the user's HP after every turn";
        }

        protected override void EndTurnEffect(object sender, EventArgs e)
        {
            if (holder != null) holder.HealPercent(0.0625);
        }
    }
}
