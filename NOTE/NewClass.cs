using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE
{
    internal class NewClass
    {
        public void Hello()
        {
            Console.Write("Hello ");
        }
        public void World()
        {
            Console.Write("World!");
        }
        public void HelloToWorld()
        {
            Hello();
            World();
        }
    }
}
