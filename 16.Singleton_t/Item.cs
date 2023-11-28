using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public abstract class Item
    {
        public Player owner = null;
        public string name;
        public string discription;
        public int price;


        public abstract void Use();

    }
}
