using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S
{
    internal class Map
    {
        public List<MapStruct> mapList = new List<MapStruct>();

        public class MapStruct
        {
            public char[,] map;
            public bool clear;
            public MapStruct(char[,] map)
            {
                this.map = map;
                clear = false;
            }
        }

        public Map()
        {
            Init();
        }

        private void Init()
        {
            mapList.Add(new MapStruct(map1));
            mapList.Add(new MapStruct(map2));
            mapList.Add(new MapStruct(map3));
        }

        private char[,] map1 =
        {
            { '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', 'P', 'G', '#', ' ', ' ', '#' },
            { '#', ' ', 'G', 'B', ' ', 'G', ' ', '#' },
            { '#', ' ', ' ', '#', 'B', ' ', ' ', '#' },
            { '#', ' ', ' ', 'B', ' ', ' ', '#', '#' },
            { '#', '#', '#', ' ', ' ', '#', '#', ' ' },
            { ' ', ' ', '#', ' ', ' ', '#', ' ', ' ' },
            { ' ', ' ', '#', '#', '#', '#', ' ', ' ' },
        };

        private char[,] map2 =
        {
            { ' ', ' ', '#', '#', '#', '#', ' ' },
            { ' ', '#', '#', ' ', ' ', '#', ' ' },
            { '#', '#', 'P', 'B', 'G', '#', '#' },
            { '#', ' ', 'B', 'B', ' ', ' ', '#' },
            { '#', ' ', 'G', ' ', 'G', ' ', '#' },
            { '#', '#', '#', ' ', ' ', ' ', '#' },
            { ' ', ' ', '#', '#', '#', '#', '#' },
        };

        private char[,] map3 =
        {
            { '#', '#', '#', '#', '#', '#', ' ', ' ' },
            { '#', ' ', 'G', ' ', ' ', '#', ' ', ' ' },
            { '#', ' ', 'G', '#', ' ', '#', '#', '#' },
            { '#', ' ', 'P', 'B', 'B', ' ', ' ', '#' },
            { '#', ' ', 'B', 'G', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#' },
        };
    }
}
