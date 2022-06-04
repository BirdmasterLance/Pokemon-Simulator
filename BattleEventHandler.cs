﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    public class BattleEventHandler
    {
        public static BattleEventHandler instance;

        public BattleEventHandler()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        #region Turn Events

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

        #endregion

        #region Switching Events

        public event EventHandler<Pokemon> OnPokemonSwitchIn;
        public void StartPokemonSwitchIn(ref Pokemon pkmn)
        {
            OnPokemonSwitchIn?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> OnPokemonSwitchOut;
        public void StartPokemonSwitchOut(ref Pokemon pkmn)
        {
            OnPokemonSwitchOut?.Invoke(this, pkmn);
        }

        #endregion

        public event EventHandler<Pokemon> OnPokemonFainted;
        public void PlayerPokemonFainted(ref Pokemon pkmn)
        {
            OnPokemonFainted?.Invoke(this, pkmn);
        }

        #region Attacking Events

        public event EventHandler<Pokemon> OnUseAttack;
        public void UseAttack(ref Pokemon pkmn)
        {
            OnUseAttack?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> OnHitByMove;
        public void HitByMove(ref Pokemon pkmn)
        {
            OnHitByMove?.Invoke(this, pkmn);
        }

        public event EventHandler<Pokemon> OnHitBySuperEffective;
        public void HitBySuperEffective(ref Pokemon pkmn)
        {
            OnHitBySuperEffective?.Invoke(this, pkmn);
        }

        #endregion
    }
}
