using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    internal abstract class Move
    {
        public Pokemon user; // The pokemon that is using this move
        public string moveName;
        public string description;
        public double damage;
        public double accuracy;
        public bool physical;
        public bool actualAttack;
        public bool recoil = false;
        public Type type;
        public int pp;
        public int maxPP;
        public bool canHealOneSelf = false;
        public bool raisesDef = false;
        public bool lowersDef = false;
        public bool raisesEspDef = false;
        public bool lowersEspDef = false;
        public bool raisesAtk = false;
        public bool raisesEspAtk = false;
        public bool lowersAtk = false;
        public bool lowersEspAtk = false;
        public Move(Pokemon user)
        {
            this.user = user;
        }

        public virtual void SpecialEffects()
        {
        }

        public virtual void SpecialTargetEffects(Pokemon target)
        {

        }

    }

    internal class Struggle : Move
    { 
        public Struggle(Pokemon user) : base(user)
        {
            damage = 50;
            accuracy = 100;
            moveName = "Struggle";
            physical = true;
            actualAttack = true;
            type = Type.None;
            pp = 10;
            maxPP = pp;
            recoil = true;
        }

    }

    internal class DazzlingGleam : Move
    {
        public DazzlingGleam(Pokemon user) : base(user)
        {
            damage = 80;
            accuracy = 100;
            moveName = "Dazzling Gleam";
            physical = false;
            actualAttack = true;
            type = Type.Fairy;
            pp = 10;
            maxPP = pp;
            canHealOneSelf = true;
            
        }
    }

    internal class MysticalFire : Move
    {
        public MysticalFire(Pokemon user) : base(user)
        {
            moveName = "Mystical Fire";
            description = "Damages and lowers the target's Special Attack by one stage";
            damage = 75;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Fire;
            pp = 10;
            maxPP = pp;
            lowersEspAtk = true;
        }

        public override void SpecialTargetEffects(Pokemon target)
        {
            target.ChangeStat(ref target.currSpecialAttack, ref target.specialAttackStage, -1);
        }
    }

    internal class Recover : Move
    {
        public Recover(Pokemon user) : base(user)
        {
            moveName = "Recover";
            description = "Restores up to 50% of the user's maximum HP";
            actualAttack = false;
            type = Type.Normal;
            pp = 5;
            maxPP = pp;
            canHealOneSelf = true;
        }

        public override void SpecialEffects()
        {
            user.currHealth += user.GetHealth() * 0.5;
        }
    }

    internal class CalmMind : Move
    {
        public CalmMind(Pokemon user) : base(user)
        {
            moveName = "Calm Mind";
            description = "Raises the user's Special Attack and Special Defense by one stage";
            actualAttack = false;
            type = Type.Psychic;
            maxPP = pp = 20;
            raisesEspAtk = true;
            raisesEspDef = true;
        }

        public override void SpecialEffects()
        {
            user.ChangeStat(ref user.currSpecialAttack, ref user.specialAttackStage, 1);
            user.ChangeStat(ref user.currSpecialDefense, ref user.specialDefenseStage, 1);
        }
    }

    internal class CloseCombat : Move
    {
        public CloseCombat(Pokemon user) : base(user)
        {
            moveName = "Close Combat";
            description = "Inflicts damage and lowers the user's defensive stats";
            damage = 120;
            accuracy = 100;
            actualAttack = true;
            type = Type.Fighting;
            maxPP = pp = 8;
            lowersDef = true;
        }

        public override void SpecialEffects()
        {
            user.ChangeStat(ref user.currDefense, ref user.defenseStage, -1);
            user.ChangeStat(ref user.currSpecialDefense, ref user.specialDefenseStage, -1);
        }
    }

    internal class IronHead : Move
    {
        public IronHead(Pokemon user) : base(user)
        {
            moveName = "Iron Head";
            description = "Inflicts damage and has a 30% to flinch the target";
            damage = 80;
            accuracy = 100;
            actualAttack = true;
            type = Type.Steel;
            maxPP = pp = 15;
        }

        public override void SpecialTargetEffects(Pokemon target)
        {
            // TODO: add 30% to flinch
        }
    }
}
