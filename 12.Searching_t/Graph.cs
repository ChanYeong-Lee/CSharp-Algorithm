using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Searching_t
{
    internal class Graph
    {
        public bool[,] graph1 = new bool[8, 8]
        {
            { false, false,  true, false,  true, false, false, false },
            { false, false,  true, false, false,  true, false, false },
            {  true,  true, false, false, false,  true,  true, false },
            { false, false, false, false, false, false, false,  true },
            {  true, false, false, false, false, false, false,  true },
            { false,  true,  true, false, false, false, false, false },
            { false, false,  true, false, false, false, false, false },
            { false, false, false,  true,  true, false, false, false },
        };

        public bool[,] graph2 = new bool[8, 8]
        {
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, false, false, false },
            { false, false, false, false,  true,  true, false, false },
            { false,  true, false, false, false,  true, false,  true },
            { false, false, false, false, false, false, false, false },
            { false,  true, false, false, false, false, false, false },
            { false, false,  true, false, false,  true, false, false },
            { false, false, false, false, false, false,  true, false },
        };

        const int INF = int.MaxValue;
        public int[,] graph3 = new int[8, 8]
        {
            {   0, INF,   8, INF,   2, INF, INF, INF },
            { INF,   0, INF, INF, INF, INF,   9, INF },
            {   8, INF,   0, INF, INF, INF,   1, INF },
            { INF, INF, INF,   0, INF,   1, INF,   4 },
            {   2, INF, INF, INF,   0, INF, INF,   1 },
            { INF, INF, INF,   1, INF,   0, INF, INF },
            { INF,   9,   1, INF, INF, INF,   0, INF },
            { INF, INF, INF,   4,   1, INF, INF,   0 },
        };
    }
}
