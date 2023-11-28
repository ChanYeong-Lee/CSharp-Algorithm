using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class TurnManager
    {
        private TurnManager()
        { }
        private static TurnManager instance;
        public static TurnManager GetInstance()
        {
            if (instance == null)
            {
                instance = new TurnManager();   
            }
            return instance;
        }

        public event Action OnBattleEnd;
        public void BattleEnd()
        {
            OnBattleEnd?.Invoke();
        }


    }
}
