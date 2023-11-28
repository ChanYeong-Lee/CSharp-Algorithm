using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Herb : Item
    {
        public int amount;
        Player ownered;
        public Herb()
        {
            name = "Herb";
            discription = "Increase User's damage 10%";
            price = 300;
        }

        public override void Use()
        {
            amount = (int)(owner.damage * 0.1);
            owner.damage += amount;
            ownered = owner;
            TurnManager.GetInstance().OnBattleEnd += Stop;
        }

        public void Stop()
        {
            ownered.damage -= amount;
        }
    }
}
