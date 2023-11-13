using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal class Shield : Item, IEquipable
    {
        public Shield()
        {
            name = "CShield";
            owner = null;
        }
        public override void Execute()
        {
            Equip();
        }
        public void Equip()
        {
            if (owner.shield == null)
            {
                owner.shield = this;
                Console.WriteLine("You Equip {0}", name);
                owner.defense += 20;
            }
            else
            {
                Console.WriteLine("You Already Have Shield");
            }
        }
        public void UnEquip()
        {
            Console.WriteLine("You UnEquip {0}", name);

            owner.defense -= 20;
        }
    }
}
