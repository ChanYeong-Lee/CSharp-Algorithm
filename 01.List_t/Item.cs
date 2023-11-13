using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List_t
{
    internal abstract class Item : IComparable<Item>

    {
        public string name;
        public Player owner;

           
        public abstract void Execute();
        int IComparable<Item>.CompareTo(Item? other)
        {
            return name.CompareTo(other.name);
        }
    }
}
