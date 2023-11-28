using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Inventory
    {
        private Player owner;
        private static Inventory instance = null;
        private Inventory()
        { }

        public List<Item> items = new List<Item>();
        public int gold;

        public static Inventory GetInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();
            }
            return instance;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            item.owner = this.owner;
        }

        public bool RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                item.owner = null;
                return true;
            }
            else
                return false;
        }

        public bool FindItem(Item item)
        {
            return items.Contains(item);
        }

        public void AddGold(int amount)
        {
            gold += amount;
        }

        public bool SpendGold(int amount)
        {
            if (gold < amount)
            {
                return false;
            }
            else
            {
                gold -= amount;
                return true;
            }
        }

        public void SetOwner(Player owner)
        {
            this.owner = owner;
        }
    }
}
