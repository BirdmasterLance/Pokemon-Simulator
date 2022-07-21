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

        #region Turn Events

        public event EventHandler StartTurn;
        public void OnStartTurn()
        {
            StartTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler EndTurn;
        public  void OnEndTurn()
        {
            EndTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler StartPlayerTurn;
        public void OnStartPlayerTurn()
        {
            StartPlayerTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler EndPlayerTurn;
        public void OnEndPlayerTurn()
        {
            EndPlayerTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler StartEnemyTurn;
        public void OnStartEnemyTurn()
        {
            StartEnemyTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler EndEnemyTurn;
        public void OnEndEnemyTurn()
        {
            EndEnemyTurn?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Switching Events

        public event EventHandler<Pokemon> PokemonSwitchIn;
        public void OnPokemonSwitchIn(Pokemon pkmn)
        {
            PokemonSwitchIn?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> PokemonSwitchOut;
        public void OnPokemonSwitchOut(Pokemon pkmn)
        {
            PokemonSwitchOut?.Invoke(this, pkmn);
        }

        #endregion

        public event EventHandler<Pokemon> PokemonFainted;
        public void OnPlayerPokemonFainted(Pokemon pkmn)
        {
            PokemonFainted?.Invoke(this, pkmn);
        }

        #region Attacking Events

        public event EventHandler<Pokemon> UseAttack;
        public void OnUseAttack(Pokemon pkmn)
        {
            UseAttack?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> HitByMove;
        public void OnHitByMove(Pokemon pkmn)
        {
            HitByMove?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> HitBySuperEffective;
        public void OnHitBySuperEffective(Pokemon pkmn)
        {
            HitBySuperEffective?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> HitByCritical;
        public void OnHitByCritical(Pokemon pkmn)
        {
            HitByCritical.Invoke(this, pkmn);
        }

        #endregion
    }
}
