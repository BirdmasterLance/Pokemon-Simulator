using Pokemon_Simulator.PokemonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    internal static class BattleData
    {
        public static List<Pokemon> pokemonList = new List<Pokemon>();
        public static List<Pokemon> enemyList = new List<Pokemon>();


        public static void SetPokemon(List<Pokemon> pkmns) { pokemonList = pkmns; }
        public static void AddPokemon(Pokemon pkmn) { pokemonList.Add(pkmn); }
        public static void RemovePokemon(Pokemon pkmn) { pokemonList.Remove(pkmn); }
        
        public static void SetEnemyPokemon(List<Pokemon> pkmns) { enemyList = pkmns; }
        public static void AddEnemyPokemon(Pokemon pkmn) { enemyList.Add(pkmn); }
        public static void AddRemovePokemon(Pokemon pkmn) { enemyList.Remove(pkmn); }
    }
}
