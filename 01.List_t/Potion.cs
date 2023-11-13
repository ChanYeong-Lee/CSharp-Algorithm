using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal class Potion : Item
    {
        public Potion()
        {
            name = "BPotion";
            owner = null;
        }
        public override void Execute()
        {
            Console.WriteLine("You Use {0}", name);
            owner.hp += 200;
        }
    }
}
