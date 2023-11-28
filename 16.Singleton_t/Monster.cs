using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Monster
    {
        public List<Item> dropList = new List<Item>();

        public string name;
        public int damage;
        public int hp;
        public int dropRate;
        public int dropEXP;

        public Monster()
        {
            name = "Monster";
            hp = 300;
            damage = 30;
            dropRate = 70;
            dropEXP = 50;
            dropList.Add(new Herb());
            dropList.Add(new BigPotion());
            dropList.Add(new SmallPotion());
        }

        public bool Die()
        {
            if (hp <= 0)
                return true;
            else
                return false;
        }

        public void Attack(Player player)
        {
            player.TakeHit(damage);
        }

        public void TakeHit(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
            }
        }


        public void Drop()
        {
            Random random = new Random();
            for (int i = 0; i < dropList.Count; i++)
            {
                if (random.Next(0, 100) <= dropRate)
                {
                    Inventory.GetInstance().AddItem(dropList[i]);
                    Console.WriteLine("{0} drop {1}", name, dropList[i].name);
                }
                else
                {
                    continue;
                }
            }
        }
        public void DropEXP(Player player)
        {
            player.EXP += dropEXP;
            if (player.LevelUp())
            {
                Console.WriteLine("Level Up!");
            }
        }
    }
}
