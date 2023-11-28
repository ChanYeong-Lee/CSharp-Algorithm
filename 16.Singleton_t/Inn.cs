using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Inn
    {
        private Inn()
        { }

        private static Inn instance;
        public static Inn GetInstance()
        {
            if (instance == null)
            {
                instance = new Inn();
            }
            return instance;
        }

        public void Rest(Player player)
        {
            if (Inventory.GetInstance().SpendGold(player.maxHp - player.hp))
            {
                player.hp = player.maxHp;
            }
        }
    }
}
