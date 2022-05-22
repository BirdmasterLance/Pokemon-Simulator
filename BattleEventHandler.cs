using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Simulator
{
    public class BattleEventHandler
    {
        public static event Action OnPlayerSwitch; 
        public static void StartPlayerSwitch()
        {
            OnPlayerSwitch?.Invoke();
        }

        public static event Action OnEnemySwitch;
        public static void StartEnemySwitch()
        {
            OnEnemySwitch?.Invoke();
        }

        public static event Action OnPlayerTurn;
        public static void StartPlayerTurn()
        {
            OnPlayerTurn?.Invoke();
        }

        public static event Action OnEnemyTurn;
        public static void StartEnemyTurn()
        {
            OnEnemyTurn?.Invoke();
        }

        public static event Action OnEndTurn;
        public static void EndTurn()
        {
            OnEndTurn?.Invoke();
        }
    }
}
