using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Searching_t2
{
    internal class Graph
    {
        public static bool[,] graph()
        {
            bool[,] graph = new bool[8, 8]
            {
                { false, false, false,  true,  true, false, false, false },
                { false, false, false,  true, false,  true,  true, false },
                { false, false, false, false, false, false,  true, false },
                {  true,  true, false, false, false,  true, false,  true },
                {  true, false, false, false, false, false,  true, false },
                { false,  true, false,  true, false, false,  true,  true },
                { false,  true,  true, false,  true,  true, false,  true },
                { false, false, false,  true, false,  true,  true, false },
            };
            return graph;
        }
    }
}
