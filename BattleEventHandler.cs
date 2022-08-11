using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    public class BattleEventHandler
    {

        // Events are best used when you want to communicate information ACROSS different classes
        // Which leads me to believe that some of these events aren't very useful, since they are only needed 
        // in the BattleWindow (unless we update CPU AI information when certain events are triggered)

        public static BattleEventHandler instance;

        public BattleEventHandler()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        // An event that calls out if the GameState (in BattleWindow.cs) has changed
        public event Action<Properties.GameState> GameStateChange;
        public void OnGameStateChange(Properties.GameState state)
        {
            GameStateChange?.Invoke(state);
        }

        #region Switching Events

        public event Action<Pokemon> PokemonSwitchIn;
        public void OnPokemonSwitchIn(Pokemon pkmn)
        {
            PokemonSwitchIn?.Invoke(pkmn);
        }

        public event Action<Pokemon> PokemonSwitchOut;
        public void OnPokemonSwitchOut(Pokemon pkmn)
        {
            PokemonSwitchOut?.Invoke(pkmn);
        }

        #endregion

        public event Action<Pokemon> PokemonFainted;
        public void OnPlayerPokemonFainted(Pokemon pkmn)
        {
            PokemonFainted?.Invoke(pkmn);
        }

        #region Attacking Events

        public event Action<Pokemon> UseAttack;
        public void OnUseAttack(Pokemon pkmn)
        {
            UseAttack?.Invoke(pkmn);
        }

        public event Action<Pokemon> HitByMove;
        public void OnHitByMove(Pokemon pkmn)
        {
            HitByMove?.Invoke(pkmn);
        }

        public event Action<Pokemon> HitBySuperEffective;
        public void OnHitBySuperEffective(Pokemon pkmn)
        {
            HitBySuperEffective?.Invoke(pkmn);
        }

        public event Action<Pokemon> HitByCritical;
        public void OnHitByCritical(Pokemon pkmn)
        {
            HitByCritical.Invoke(pkmn);
        }

        public event Action<Pokemon, string> HitByStatus;
        public void OnHitByStatus(Pokemon pkmn, string statusName)
        {
            HitByStatus.Invoke(pkmn, statusName);
        }

        public event Action<Pokemon, string> HitByStatLower;
        public void OnHitByStatLower(Pokemon pkmn, string statName)
        {
            HitByStatLower.Invoke(pkmn, statName);
        }

        public event Action<Pokemon, string> HitByStatRaise;
        public void OnHitByStatRaise(Pokemon pkmn, string statName)
        {
            HitByStatRaise.Invoke(pkmn, statName);
        }

        // Might be unneeded
        public event Action<Pokemon, string> SkippedTurn;
        public void OnSkippedTurn(Pokemon pkmn, string reason)
        {
            SkippedTurn?.Invoke(pkmn, reason);
        }

        #endregion
    }
}
