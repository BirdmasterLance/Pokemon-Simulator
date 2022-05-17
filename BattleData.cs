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

        public static void AddPokemon(Pokemon pkmn) { pokemonList.Add(pkmn); }

        public static void RemovePokemon(Pokemon pkmn) { pokemonList.Remove(pkmn); }

        public static void AddEnemyPokemon(Pokemon pkmn) { enemyList.Add(pkmn); }
    }
}
