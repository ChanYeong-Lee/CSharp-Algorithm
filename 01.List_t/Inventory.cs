using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal class Inventory
    {
        private event Action OnItems;
        private List<Item> items = new List<Item>();
        

        public Inventory() 
        {
            OnItems += ShowAmount;
            OnItems += ShowInventory;
        }  
        public void GetItem(Item item)
        {
            Console.WriteLine("You Get {0}", item.name);
            items.Add(item);
            OnItems();
        }
        public void UseItem(Item item)
        {
            items[items.IndexOf(item)].Execute();
            items.RemoveAt(items.IndexOf(item));
            OnItems();
        }
        public void UseItem(int index)
        {
            items[index].Execute();
            items.RemoveAt(index);
            OnItems();
        }

        public void ShowAmount()
        {
            Console.WriteLine("You have {0} items.", items.Count);
        }
        public void CheckItem(Item item)
        {
            if (items.Contains(item))
            {
                Console.WriteLine("You have {0}, It's index is {1}", item.name, items.IndexOf(item));
            }
            else
            {
                Console.WriteLine("You don't have that.");
            }
        }

        public void Sort()
        {
            items.Sort();
        }

        public void ShowInventory()
        {
            Console.WriteLine("INVENTORY");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].name);
            }
            Console.WriteLine();
        }
    }
}
