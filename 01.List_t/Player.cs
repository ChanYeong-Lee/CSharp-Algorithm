using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal class Player
    {
        public event Action OnUse;
        public Player()
        {
            name = "Player";
            hp = 500;
            attack = 20;
            defense = 10;
            OnUse += ShowStats;
        }
        public Inventory inventory = new Inventory();
        public string name;
        public int hp;
        public int attack;
        public int defense;
        public IEquipable weapon;
        public IEquipable shield;
        public void GetItem(Item item)
        {
            item.owner = this;
            inventory.GetItem(item);
        }
        public void UseItem(Item item)
        {
            inventory.UseItem(item);
            OnUse();
        }

        public void UseItem(int index)
        {
            inventory.UseItem(index);
            OnUse();
        }


        public void ShowStats()
        {
            Console.WriteLine("Name = {0}", name);
            Console.WriteLine("Hp = {0}", hp);
            Console.WriteLine("Attack = {0}", attack);
            Console.WriteLine("Defense = {0}", defense);
        }
        public void CheckItem(Item item)
        {
            inventory.CheckItem(item);
        }

        public void ShowInventory()
        {
            inventory.ShowInventory();
        }

        public void SortInventory()
        {
            inventory.Sort();
        }

        public void UnEquip(string equipment)
        {
            switch (equipment)
            {
                case "weapon":
                case "Weapon":
                case "WEAPON":
                    if (weapon != null)
                    {
                        weapon.UnEquip();
                        inventory.GetItem((Item)weapon);
                        weapon = null;
                    }
                    break;
                case "shield":
                case "Shield":
                case "SHIELD":
                    if (shield != null)
                    {
                        shield.UnEquip();
                        inventory.GetItem((Item)shield);
                        shield = null;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
