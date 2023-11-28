using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S2
{
    public class Map
    {
        public List<MapStruct> maps = new List<MapStruct>();

        public struct MapStruct
        {
            public char[,] map;
            public int level;
            public bool clear;

            public MapStruct(char[,] map, int level)
            {
                this.map = map;
                this.level = level;
                clear = false;
            }
        }

        public int level;
        public bool clear;

        public void Init()
        {
            char[,] map1 =
        {
            { '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', 'B', 'G', ' ', '#' },
            { '#', ' ', 'P', ' ', 'B', 'G', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#' },
        };
            maps.Add(new MapStruct(map1, 1));

            char[,] map2 =
            {
            { '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#' },
        };
            maps.Add(new MapStruct(map2, 2));

        }
    }
}

