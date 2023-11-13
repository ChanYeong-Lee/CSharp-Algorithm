using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal class Sword : Item, IEquipable
    {
        public Sword()
        {
            name = "ASword";
            owner = null;
        }
        public override void Execute()
        {
            Equip();
        }
        public void Equip()
        {
            if (owner.weapon == null)
            {
                owner.weapon = this;
                Console.WriteLine("You Equip {0}", name);
                owner.attack += 20; 
            }
            else
            {
                Console.WriteLine("You Already Have Weapon");
            }
        }
        public void UnEquip()
        {
            Console.WriteLine("You UnEquip {0}", name);
            owner.attack -= 20;
        }
    }
}
