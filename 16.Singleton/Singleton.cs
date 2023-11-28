using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton
{
    
    public abstract class Singleton<T> where T : new()
    {
        protected static T instance;
        protected Singleton() { }

        public static T GetInstance()
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;
        }
    }

    public class Item
    {
        public void UseItem()
        {

        }
    }

    public class Inventory
    {
        public Inventory() 
        {
            gold = 100;
        }
        List<Item> items = new List<Item>();

        int gold;

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void AddGold(int amount)
        {
            gold += amount;
        }
    }

    public class Monster
    {
        int dropGold = 100;
        Item dropItem = new Item();
        public void Die()
        {
            Singleton<Inventory>.GetInstance().AddItem(dropItem);
            Singleton<Inventory>.GetInstance().AddGold(dropGold);
        }
    }

    public class Player
    {
        public Inventory inventory = Singleton<Inventory>.GetInstance();
        public void UseItem(Item item)
        {
            item.UseItem();
            inventory.RemoveItem(item);
        }
    }
}
