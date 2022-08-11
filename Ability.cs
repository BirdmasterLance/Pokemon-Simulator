namespace Pokemon_Simulator
{
    public abstract class Ability
    {
        public string abilityName { get; protected set; }
        public string description { get; protected set; }
        protected Pokemon user;

        public Ability(Pokemon user)
        {
            this.user = user;

            BattleEventHandler.instance.PokemonSwitchIn += SwitchInEffect;
            BattleEventHandler.instance.PokemonSwitchOut += SwitchOutEffect;
            BattleEventHandler.instance.PokemonFainted += FaintEffect;
            BattleEventHandler.instance.HitByMove += HitByEffect;
            BattleEventHandler.instance.HitBySuperEffective += HitBySuperEffectiveEffect;
            BattleEventHandler.instance.HitByCritical += HitByCriticalEffect;
            BattleEventHandler.instance.HitByStatus += StatusEffect;
            BattleEventHandler.instance.HitByStatLower += StatLowerEffect;
            BattleEventHandler.instance.HitByStatRaise += StatRaiseEffect;
            BattleEventHandler.instance.SkippedTurn += SkippedTurnEffect;
        }

        public virtual void SwitchInEffect(Pokemon pokemon) { }
        public virtual void SwitchOutEffect(Pokemon pokemon) { }
        public virtual void FaintEffect(Pokemon pokemon) { }
        public virtual void HitByEffect(Pokemon pokemon) { }
        public virtual void HitBySuperEffectiveEffect(Pokemon pokemon) { }
        public virtual void HitByCriticalEffect(Pokemon pokemon) { }
        public virtual void StatusEffect(Pokemon pokemon, string statusName) { }
        public virtual void StatLowerEffect(Pokemon pokemon, string statName) { }
        public virtual void StatRaiseEffect(Pokemon pokemon, string statName) { }
        public virtual void SkippedTurnEffect(Pokemon pokemon, string reason) { }
    }

    public class MarvelScale : Ability
    {
        public MarvelScale(Pokemon user) : base(user)
        {
            abilityName = "Marvel Scale";
            description = "If the pokemon is hit by a status move, raise its defense by 1.5x";
        }

        public override void StatusEffect(Pokemon pokemon, string statusName)
        {
            if(statusName == "Burn" || statusName == "Paralysis" || statusName == "Poison" || statusName == "Toxic" || statusName == "Freeze" || statusName == "Sleep")
            {
                if (pokemon.Equals(user)) pokemon.currDefense *= 1.5;
            }
        }
    }

    public class NaturalCure : Ability
    {
        public NaturalCure(Pokemon user) : base(user)
        {
            abilityName = "Natural Cure";
            description = "Pokemon is cured of its status effects when it switches out";
        }

        public override void SwitchOutEffect(Pokemon pokemon)
        {
            if (pokemon.Equals(user)) pokemon.currentStatusEffect = null;
        }
    }
}
