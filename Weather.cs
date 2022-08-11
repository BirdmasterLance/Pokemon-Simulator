using Pokemon_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    //public enum Weather
    //{
    //    Sunlight,
    //    Rain,
    //    Sandstorm,
    //    Hail,
    //    TrickRoom,
    //    LightScreen,
    //    Reflect,
    //    AuroraVeil,
    //    None
    //}

    public abstract class Weather
    {
        public string weatherName { get; protected set; }
        protected int turnsElasped;
        protected int maxTurns;
        protected Color color;
        protected Pokemon user;

        public Weather(int maxTurns, Pokemon user=null)
        {
            this.maxTurns = maxTurns;
            this.user = user;

            BattleEventHandler.instance.GameStateChange += EndTurnEffect;
            BattleEventHandler.instance.PokemonSwitchIn += SwitchInEffect;
        }

        public virtual void SwitchInEffect(Pokemon pokemon) { }

        public virtual void EndTurnEffect(GameState state) 
        {
            if(state == GameState.EndTurn)
            {
                turnsElasped++;
                Console.WriteLine(weatherName + " elasped by 1 turn");
                if (turnsElasped == maxTurns)
                {
                    if (BattleData.currentWeather.weatherName == weatherName) BattleData.SetMainWeather(null);
                    if(user != null)
                    {
                        if (user.Equals(BattleWindow.instance.activePokemon)) BattleData.RemoveSubWeather(ref BattleData.playerSubWeather, weatherName);
                        if (user.Equals(BattleWindow.instance.activeEnemyPokemon)) BattleData.RemoveSubWeather(ref BattleData.enemySubWeather, weatherName);
                    }
                     BattleWindow.instance.ResetBackground();
                    Console.WriteLine(weatherName + " has ended");
                }
            }          
        }

        public Color GetColor() { return color; }
    }

    class Sunlight : Weather
    {
        public Sunlight(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Sunlight";
            color = Color.FromArgb(230, 120, 0);
        }
    }

    class Rain : Weather
    {
        public Rain(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Rain";
            color = Color.FromArgb(0, 100, 220);
        }
    }

    class Sandstorm : Weather
    {
        public Sandstorm(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Sandstorm";
            color = Color.FromArgb(191, 161, 77);
        }

        public override void SwitchInEffect(Pokemon pokemon)
        {
            if (pokemon.type1 == Type.Rock || pokemon.type2 == Type.Rock) pokemon.currSpecialDefense *= 1.5;           
        }

        public override void EndTurnEffect(GameState state)
        {
            if(state == GameState.EndTurn)
            {
                Pokemon activePokemon = BattleWindow.instance.activePokemon;
                Pokemon activeEnemyPokemon = BattleWindow.instance.activeEnemyPokemon;

                if ((activePokemon.type1 != Type.Rock && activePokemon.type1 != Type.Ground && activePokemon.type1 != Type.Steel) &&
                    (activePokemon.type2 != Type.Rock && activePokemon.type2 != Type.Ground && activePokemon.type2 != Type.Steel))
                {
                    activePokemon.currHealth -= activePokemon.currHealth / 16;
                }
                if ((activeEnemyPokemon.type1 != Type.Rock && activeEnemyPokemon.type1 != Type.Ground && activeEnemyPokemon.type1 != Type.Steel) &&
                    (activeEnemyPokemon.type2 != Type.Rock && activeEnemyPokemon.type2 != Type.Ground && activeEnemyPokemon.type2 != Type.Steel))
                {
                    activeEnemyPokemon.currHealth -= activeEnemyPokemon.currHealth / 16;
                }
                base.EndTurnEffect(state);
            }         
        }
    }

    class Hail : Weather
    {
        public Hail(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Hail";
            color = Color.FromArgb(0, 200, 220);
        }

        public override void EndTurnEffect(GameState state)
        {
            if (state == GameState.EndTurn)
            {
                Pokemon activePokemon = BattleWindow.instance.activePokemon;
                Pokemon activeEnemyPokemon = BattleWindow.instance.activeEnemyPokemon;

                if (activePokemon.type1 != Type.Ice && activePokemon.type2 != Type.Ice)
                {
                    activePokemon.currHealth -= activePokemon.currHealth / 16;
                }
                if (activeEnemyPokemon.type1 != Type.Ice && activeEnemyPokemon.type2 != Type.Ice)
                {
                    activeEnemyPokemon.currHealth -= activeEnemyPokemon.currHealth / 16;
                }
            }           
            base.EndTurnEffect(state);
        }
    }

    class TrickRoom : Weather
    {
        public TrickRoom(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Trick Room";
        }
    }

    class Reflect : Weather
    {
        public Reflect(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Reflect";
        }
    }

    class LightScreen : Weather
    {
        public LightScreen(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Light Screen";
        }
    }

    class AuroraVeil : Weather
    {
        public AuroraVeil(int maxTurns, Pokemon user = null) : base(maxTurns, user)
        {
            weatherName = "Aurora Veil";
        }
    }

}
