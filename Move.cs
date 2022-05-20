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
        public string description;
        public double damage;
        public double accuracy;
        public string moveName;
        public bool physical;
        public bool actualAttack;
        public bool recoil = false;
        public string type;
        public int pp;
        public int maxPP;
        public bool canHeal = false;
        public bool raisesDef = false;
    
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
            type = "None";
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
            type = "Fairy";
            pp = 10;
            maxPP = pp;
            canHeal = true;
            raisesDef = false;
        }
    }

    internal class MysticalFire : Move
    {
        public MysticalFire(Pokemon user) : base(user)
        {
            damage = 75;
            accuracy = 100;
            moveName = "Mystical Fire";
            physical = false;
            actualAttack = true;
            type = "Fire";
            pp = 10;
            maxPP = pp;
        }

        public override void SpecialTargetEffects(Pokemon target)
        {
            target.currSpecialAttack *= 0.8;
        }
    }

    internal class Recover : Move
    {
        public Recover(Pokemon user) : base(user)
        {
            moveName = "Recover";
            actualAttack = false;
            type = "Normal";
            pp = 5;
            maxPP = pp;
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
            actualAttack = false;
            type = "Psychic";
            pp = 20;
            maxPP = pp;
        }

        public override void SpecialEffects()
        {
            user.currSpecialAttack *= 1.5;
            user.currSpecialDefense *= 1.5;
        }
    }
}
