using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class SmallPotion : Item
    {
        public int amount;
        public SmallPotion()
        {
            amount = 20;
            name = "SmallPotion";
            discription = "Heal 20hp";
            price = 100;
        }

        public override void Use()
        {
            Console.WriteLine("{0} is healed {1}hp",owner.name, amount);
        }
    }
}
