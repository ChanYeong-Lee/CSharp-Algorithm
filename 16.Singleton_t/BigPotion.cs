using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class BigPotion : Item
    {
        public int amount;
        public BigPotion()
        {
            name = "BigPotion";
            discription = "Heal 50hp";
            price = 200;
            amount = 50;
        }

        public override void Use()
        {
            Console.WriteLine("{0} is healed {1}hp", owner.name, amount);
        }
    }
}
