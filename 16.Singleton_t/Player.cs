using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Player
    {
        Inventory inventory = Inventory.GetInstance();

        public int damage;
        public string name;
        public int hp;
        public int maxHp;
        public int EXP;
        public int level;

        public Player()
        {
            inventory.SetOwner(this);
            name = "Player";
            hp = 200;
            maxHp = 200;
            level = 1;
            damage = 50;
            inventory.AddItem(new SmallPotion());
            inventory.AddItem(new BigPotion());
            inventory.AddItem(new Herb());
            inventory.AddGold(3000);
        }

        public bool UseItem(Item item)
        {
            if (inventory.FindItem(item))
            {
                item.Use();
                inventory.RemoveItem(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuyItem(Item item)
        {
            if (Shop.GetInstance().FindItem(item))
            {
                if (inventory.SpendGold(item.price))
                {
                    Shop.GetInstance().SellItem(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool SellItem(Item item)
        {
            if (inventory.FindItem(item))
            {
                inventory.RemoveItem(item);
                Shop.GetInstance().BuyItem(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Attack(Monster monster)
        {
            monster.TakeHit(damage);
        }

        public bool Die()
        {
            if (hp <= 0)
                return true;
            else
                return false;
        }
        public void TakeHit(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
            }
        }

        public bool LevelUp()
        {
            if (EXP >= 20 * level + 30)
            {
                level++;
                damage += 10;
                maxHp += 50;
                return true;
            }
            else
                return false;
        }
    }
}
