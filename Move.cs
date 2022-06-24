using Pokemon_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    public abstract class Move
    {
        public Pokemon user; // The pokemon that is using this move
        public string moveName;
        public string description;
        public double damage;
        public double accuracy = 100;
        public bool physical;
        public bool actualAttack;
        public bool recoil = false;
        public Type type;
        public int pp;
        public int maxPP;
        public double criticalHitChance = 0.417;

        // Info about what the move does
        public bool canHealOneSelf = false;
        public bool canAbsorb = false;

        public bool canFlinch = false;
        public bool causesStatus = false;

        public bool raisesAtk = false;
        public bool lowersAtk = false;
        public bool lowersAtkSelf = false;

        public bool raisesDef = false;
        public bool lowersDef = false;
        public bool lowersDefSelf = false;

        public bool raisesEspAtk = false;
        public bool lowersEspAtk = false;
        public bool lowersEspAtkSelf = false;

        public bool raisesEspDef = false;
        public bool lowersEspDef = false;
        public bool lowersEspDefSelf = false;

        public bool raisesSpeed = false;
        public bool lowersSpeed = false;
        public bool lowersSpeedSelf = false;

        public bool raisesAccuracy = false;
        public bool lowersAccuracy = false;

        public bool raisesEvasion = false;
        public bool lowersEvasion = false;
        public int moveCounter = 0;

        public Move(Pokemon user)
        {
            this.user = user;
        }

        public virtual void SpecialEffects()
        {
        }

        public virtual void SpecialTargetEffects( Pokemon target)
        {

        }

    }

    // 0, 100, 220 for rain
    // 0, 200, 220 for hail
    // 230, 120, 0 for sun
    // 191, 161, 77 for sandstorm

    internal class TestMove : Move
    {
        public TestMove(Pokemon user) : base(user)
        {
            damage = 0;
            type = Type.None;
            maxPP = pp = 30;
        }

        public override void SpecialTargetEffects(Pokemon target)
        {
            BattleWindow.instance.TintBackgroundColor(191, 161, 77);
            BattleWindow.instance.SetWeather(Weather.Sandstorm, 5);
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

        public override void SpecialTargetEffects( Pokemon target)
        {
            target.ChangeStat(target.GetSpecialAttack(), ref target.currSpecialAttack, ref target.specialAttackStage, -1);

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
            pp = 16;
            maxPP = pp;
            canHealOneSelf = true;
        }

        public override void SpecialEffects()
        {
            user.HealPercent(0.5);
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
            user.ChangeStat(user.GetSpecialAttack(), ref user.currSpecialAttack, ref user.specialAttackStage, 1);
            user.ChangeStat(user.GetSpecialDefense(), ref user.currSpecialDefense, ref user.specialDefenseStage, 1);
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
            physical = true;
            actualAttack = true;
            type = Type.Fighting;
            maxPP = pp = 8;
            lowersDefSelf = true;
            lowersEspDefSelf = true;
        }

        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetDefense(), ref user.currDefense, ref user.defenseStage, -1);
            user.ChangeStat(user.GetSpecialDefense(), ref user.currSpecialDefense, ref user.specialDefenseStage, -1);
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
            physical = true;
            actualAttack = true;
            type = Type.Steel;
            maxPP = pp = 15;
            canFlinch = true;
        }

        public override void SpecialTargetEffects( Pokemon target)
        {
            // TODO: add 30% to flinch
        }
    }

    internal class SludgeBomb : Move
    {
        public SludgeBomb(Pokemon user) : base(user)
        {
            moveName = "Sludge Bomb";
            description = "Inflicts damage and has a 30% to poison the target";
            damage = 90;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Poison;
            maxPP = pp = 16;
            causesStatus = true;
        }

        public override void SpecialTargetEffects( Pokemon target)
        {
            Random rand = new Random();
            if (rand.Next() <= 0.3)
            {
                target.SetStatusEffect(new PoisonStatusEffect(target));
            }
        }
    }

    internal class LeafStorm : Move
    {
        public LeafStorm(Pokemon user) : base(user)
        {
            moveName = "Leaf Storm";
            description = "Inflicts damage and lowers the user's Special Attack by 2 stages";
            damage = 130;
            accuracy = 90;
            physical = false;
            actualAttack = true;
            type = Type.Grass;
            maxPP = pp = 16;
            lowersEspAtkSelf = true;
        }

        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetSpecialAttack(), ref user.currSpecialAttack, ref user.specialAttackStage, -2);
        }
    }

    internal class Synthesis : Move
    {
        public Synthesis(Pokemon user) : base(user)
        {
            moveName = "Synthesis";
            description = "Heals the user by a weather dependent amount";
            actualAttack = false;
            type = Type.Grass;
            maxPP = pp = 8;
            canHealOneSelf = true;
        }

        public override void SpecialEffects()
        {
            // TODO: it heals more in sun 2/3 and less in other weathers 1/4
            user.HealPercent(0.5);
        }
    }

    internal class HiddenPower : Move
    {
        public HiddenPower(Pokemon user, Type actualType) : base(user)
        {
            moveName = "Hidden Power";
            description = "Inflicts damage";
            damage = 60;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = actualType;
            maxPP = pp = 24;
        }
    }

    internal class FireBlast : Move
    {
        public FireBlast(Pokemon user) : base(user)
        {
            moveName = "Fire Blast";
            description = "Inflicts damage and has a 10% to burn the target";
            damage = 110;
            accuracy = 85;
            physical = false;
            actualAttack = true;
            type = Type.Fire;
            maxPP = pp = 8;
            causesStatus = true;
        }

        public override void SpecialTargetEffects( Pokemon target)
        {
            Random rand = new Random();
            if (rand.Next() <= 0.1)
            {
                target.SetStatusEffect(new BurnStatusEffect(target));
            }
        }
    }

    internal class Psychic : Move
    {
        public Psychic(Pokemon user) : base(user)
        {
            moveName = "Psychic";
            description = "Inflicts damage and has a 10% to lower the target's Special Defense by 1 stage";
            damage = 90;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Psychic;
            maxPP = pp = 16;
            lowersEspDef = true;
        }
        public override void SpecialTargetEffects( Pokemon target)
        {
            Random rand = new Random();
            int randInt = rand.Next(1, 10);
            if (randInt == 1)
            {
                target.ChangeStat(user.GetSpecialDefense(), ref target.currSpecialDefense, ref target.specialDefenseStage, -1);
            }
        }
    }

    internal class GrassKnot : Move
    {
        public GrassKnot(Pokemon user) : base(user)
        {
            moveName = "Grass Knot";
            description = "Inflicts damage based on the target's weight";
            damage = 70;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Grass;
            maxPP = pp = 32;
        }
        public override void SpecialTargetEffects( Pokemon target)
        {
            // TODO: weight.
        }
    }

    internal class Scald : Move
    {
        public Scald(Pokemon user) : base(user)
        {
            moveName = "Scald";
            description = "Inflicts damage and has a 30% chance to burn the target. Also thaws them";
            damage = 80;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Water;
            maxPP = pp = 24;
            causesStatus = true;
        }
        public override void SpecialTargetEffects( Pokemon target)
        {
            Random rand = new Random();
            if (rand.Next() <= 0.3)
            {
                target.SetStatusEffect(new BurnStatusEffect(target));
            }
        }
    }

    internal class IceBeam : Move
    {
        public IceBeam(Pokemon user) : base(user)
        {
            moveName = "Ice Beam";
            description = "Inflicts damage and has a 10% chance to freeze the target";
            damage = 90;
            accuracy = 100;
            physical = false;
            actualAttack = true;
            type = Type.Ice;
            maxPP = pp = 16;
            causesStatus = true;
        }
        public override void SpecialTargetEffects( Pokemon target)
        {
            Random rand = new Random();
            if (rand.Next() <= 0.1)
            {
                target.SetStatusEffect(new FreezeStatusEffect(target));
            }
        }
    }

    internal class Toxic : Move
    {
        public Toxic(Pokemon user) : base(user)
        {
            moveName = "Toxic";
            description = "Poisons the target harshly. Poison Types don't miss";
            accuracy = 90;
            physical = false;
            actualAttack = false;
            type = Type.Poison;
            maxPP = pp = 16;
            causesStatus = true;
        }
        public override void SpecialTargetEffects( Pokemon target)
        {
            target.SetStatusEffect(new ToxicStatusEffect(target));
        }
    }
    internal class IronDefense : Move
    {
        public IronDefense(Pokemon user) : base(user)
        {
            moveName = "Iron Defense";
            description = "Raises the user's Defense by 2 stages";
            actualAttack = false;
            type = Type.Steel;
            maxPP = pp = 24;
            raisesDef = true;
        }
        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetDefense(), ref user.currDefense, ref user.defenseStage, 2);
        }
    }

    internal class MeteorMash : Move
    {
        public MeteorMash(Pokemon user) : base(user)
        {
            moveName = "Meteor Mash";
            description = "Inflicts damage and has a 20% chance to raise the user's Attack by 1 stage";
            damage = 90;
            accuracy = 90;
            actualAttack = true;
            physical = true;
            type = Type.Steel;
            maxPP = pp = 16;
            raisesAtk = true;
        }

        public override void SpecialEffects()
        {
            Random rand = new Random();
            if (rand.Next() <= 0.2)
            {
                user.ChangeStat(user.GetAttack(), ref user.currAttack, ref user.attackStage, 1);
            }
        }
    }

    internal class Earthquake : Move
    {
        public Earthquake(Pokemon user) : base(user)
        {
            moveName = "Earthquake";
            description = "Inflicts damage and deals double damage to buried opponents";
            damage = 100;
            accuracy = 100;
            actualAttack = true;
            physical = true;
            type = Type.Ground;
            maxPP = pp = 16;
            raisesAtk = true;
        }
    }

    internal class BulkUp : Move
    {
        public BulkUp(Pokemon user) : base(user)
        {
            moveName = "Bulk Up";
            description = "Raises the user's Attack and Defense by 1 stage";
            actualAttack = false;
            type = Type.Fighting;
            maxPP = pp = 32;
            raisesAtk = true;
            raisesDef = true;
        }
        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetAttack(), ref user.currAttack, ref user.attackStage, 1);
            user.ChangeStat(user.GetDefense(), ref user.currDefense, ref user.defenseStage, 1);
        }
    }

    internal class WorkUp : Move
    {
        public WorkUp(Pokemon user) : base(user)
        {
            moveName = "Work Up";
            description = "Raises the user's Attack and Special Attack by 1 stage";
            actualAttack = false;
            type = Type.Normal;
            maxPP = pp = 32;
            raisesAtk = true;
            raisesDef = true;
        }
        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetAttack(), ref user.currAttack, ref user.attackStage, 1);
            user.ChangeStat(user.GetSpecialAttack(), ref user.currSpecialAttack, ref user.specialAttackStage, 1);
        }
    }

    internal class SuckerPunch : Move
    {
        public SuckerPunch(Pokemon user) : base(user)
        {
            moveName = "Sucker Punch";
            description = "Usually goes first. Fails if the target does not attacking";
            damage = 70;
            accuracy = 100;
            actualAttack = true;
            physical = true;
            type = Type.Dark;
            maxPP = pp = 8;
        }

        public override void SpecialEffects()
        {
            // TODO: priority 1 if target is going to attack, fail if otherwise
        }
    }

    internal class ExtremeSpeed : Move
    {
        public ExtremeSpeed(Pokemon user) : base(user)
        {
            moveName = "Extreme Speed";
            description = "Usually goes first";
            damage = 80;
            accuracy = 100;
            actualAttack = true;
            physical = true;
            type = Type.Normal;
            maxPP = pp = 8;
        }

        public override void SpecialEffects()
        {
            // TODO: priority 2
        }
    }

    internal class HyperVoice : Move
    {
        public HyperVoice(Pokemon user) : base(user)
        {
            moveName = "Hyper Voice";
            description = "Inflicts damage";
            damage = 90;
            accuracy = 100;
            actualAttack = true;
            physical = false;
            type = Type.Normal;
            maxPP = pp = 15;
        }

        public override void SpecialEffects()
        {
            // TODO: bypass substitue
        }
    }

    internal class Snarl : Move
    {
        public Snarl(Pokemon user) : base(user)
        {
            moveName = "Snarl";
            description = "Inflicts damage and lowers the target's Special Attack by 1 stage";
            damage = 65;
            accuracy = 90;
            actualAttack = true;
            physical = false;
            type = Type.Dark;
            maxPP = pp = 24;
        }

        public override void SpecialTargetEffects( Pokemon target)
        {
            target.ChangeStat(user.GetSpecialAttack(), ref target.currSpecialAttack, ref target.specialAttackStage, -1);
        }
    }

    internal class QuiverDance : Move
    {
        public QuiverDance(Pokemon user) : base(user)
        {
            moveName = "Quiver Dance";
            description = "Raises the user's Special Attack, Special Defense, and Speed by 1 stage";
            actualAttack = false;
            type = Type.Bug;
            maxPP = pp = 32;
            raisesEspAtk = true;
            raisesEspDef = true;
            raisesSpeed = true;
        }
        public override void SpecialEffects()
        {
            user.ChangeStat(user.GetSpecialAttack(), ref user.currSpecialAttack, ref user.specialAttackStage, 1);
            user.ChangeStat(user.GetSpecialDefense(), ref  user.currSpecialDefense, ref user.specialDefenseStage, 1);
            user.ChangeStat(user.GetSpeed(), ref user.currSpeed, ref user.speedStage, 1);
        }
    }

    internal class Headbutt : Move
    {
        public Headbutt(Pokemon user) : base(user)
        {
            moveName = "Headbutt";
            description = "Inflicts damage and has a 30% chance to flinch the target";
            damage = 70;
            accuracy = 100;
            actualAttack = true;
            physical = true;
            type = Type.Normal;
            maxPP = pp = 24;
        }

        public override void SpecialEffects()
        {
            // TODO: flinch
        }
    }

    internal class RainDance : Move
    {
        private int maxTurns;
        public RainDance(Pokemon user, int maxTurns=5) : base(user)
        {
            moveName = "Rain Dance";
            description = "Sets the weather to rain";
            actualAttack = false;
            type = Type.Water;
            maxPP = pp = 8;
            this.maxTurns = maxTurns;
        }

        public override void SpecialEffects()
        {
            BattleWindow.instance.SetWeather(Weather.Rain, maxTurns);
            BattleWindow.instance.TintBackgroundColor(0, 100, 220);
        }
    }
}
