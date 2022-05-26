using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    public class BattleEventHandler
    {

        public event EventHandler OnStartTurn;
        public void StartTurn()
        {
            OnStartTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnEndTurn;
        public  void EndTurn()
        {
            OnEndTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnStartPlayerTurn;
        public void StartPlayerTurn()
        {
            OnStartPlayerTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnEndPlayerTurn;
        public void EndPlayerTurn()
        {
            OnEndPlayerTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnStartEnemyTurn;
        public void StartEnemyTurn()
        {
            OnStartEnemyTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnEndEnemyTurn;
        public void EndEnemyTurn()
        {
            OnEndEnemyTurn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnPlayerSwitch;
        public void StartPlayerSwitch()
        {
            OnPlayerSwitch?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnEnemySwitch;
        public void StartEnemySwitch()
        {
            OnEnemySwitch?.Invoke(this, EventArgs.Empty);
        }

        // Meant for when ONE pokemon faints
        public event EventHandler OnPlayerPokemonFainted;
        public void PlayerPokemonFainted()
        {
            OnPlayerPokemonFainted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnEnemyPokemonFainted;
        public void EnemyPokemonFainted()
        {
            OnEnemyPokemonFainted?.Invoke(this, EventArgs.Empty);
        }
    }
}
