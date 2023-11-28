using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Shop
    {
        public List<Item> sellLists = new List<Item>();

        private Shop()
        {
            sellLists.Add(new SmallPotion());
            sellLists.Add(new BigPotion());
            sellLists.Add(new Herb());
        }

        private static Shop instance = null;

        public static Shop GetInstance()
        {
            if (instance == null)
            {
                instance = new Shop();
            }
            return instance;
        }

        public void BuyItem(Item item)
        {
            sellLists.Add(item);
            Inventory.GetInstance().AddGold(item.price);
        }

        public bool FindItem(Item item)
        {
            return sellLists.Contains(item);
        }

        public void SellItem(Item item)
        {
            sellLists.Remove(item);
            Inventory.GetInstance().AddItem(item);
        }

        public void FillItems()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(0, 7); i++)
            {
                int rndValue = random.Next(0, 3);
                if (rndValue == 0)
                    sellLists.Add(new BigPotion());
                else if (rndValue == 1)
                    sellLists.Add(new SmallPotion());
                else
                    sellLists.Add(new Herb());
            }
            if (sellLists.Count > 10)
            {
                while (sellLists.Count == 10)
                {
                    sellLists.Last();
                }
            }
        }
    }
}
