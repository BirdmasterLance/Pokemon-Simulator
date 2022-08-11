using Pokemon_Simulator.PokemonClasses;
using Pokemon_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    internal static class BattleData
    {
        public static int turnCounter = 0;

        public static List<Pokemon> pokemonList = new List<Pokemon>();
        public static List<Pokemon> enemyList = new List<Pokemon>();

        public static void SetPokemon(List<Pokemon> pkmns) { pokemonList = pkmns; }
        public static void AddPokemon(Pokemon pkmn) { pokemonList.Add(pkmn); }
        public static void RemovePokemon(Pokemon pkmn) { pokemonList.Remove(pkmn); }

        public static void SetEnemyPokemon(List<Pokemon> pkmns) { enemyList = pkmns; }
        public static void AddEnemyPokemon(Pokemon pkmn) { enemyList.Add(pkmn); }
        public static void AddRemovePokemon(Pokemon pkmn) { enemyList.Remove(pkmn); }

        public static Weather currentWeather { get; private set; }
        public static HashSet<Weather> playerSubWeather = new HashSet<Weather>();
        public static HashSet<Weather> enemySubWeather = new HashSet<Weather>();

        public static void SetMainWeather(Weather weather)
        {
            currentWeather = weather;
            if(weather != null) BattleWindow.instance.TintBackgroundColor(weather.GetColor().R, weather.GetColor().G, weather.GetColor().B);
        }
        
        public static void RemoveSubWeather(ref HashSet<Weather> weatherSet, string weather)
        {
            weatherSet.Remove(HasSubWeather(ref weatherSet, weather));
        }

        public static Weather HasSubWeather(ref HashSet<Weather> subWeatherSet, string weather)
        {
            foreach (Weather currentWeather in subWeatherSet)
            {
                if (currentWeather.weatherName == weather) return currentWeather;
            }
            return null;
        }       
    }
}
