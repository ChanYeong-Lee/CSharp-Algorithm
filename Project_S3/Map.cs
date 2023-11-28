using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S3
{
    public class Map
    {
        public List<MapStruct> maps = new List<MapStruct>();
        public struct MapStruct
        {
            public char[,] map;
            public bool clear;
            public int mapNumber;

            public MapStruct(char[,] map, int mapNumber)
            {
                this.map = map;
                this.clear = false;
                this.mapNumber = mapNumber; 
            }
        }

        public void Init()
        {
            char[,] map1 =
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
            maps.Add(new MapStruct(map1, 0));
            char[,] map2 =
            {
                { ' ', ' ', '#', '#', '#', '#', ' ' },
                { ' ', '#', '#', ' ', ' ', '#', ' ' },
                { '#', '#', 'P', 'B', 'G', '#', '#' },
                { '#', ' ', 'B', 'B', ' ', ' ', '#' },
                { '#', ' ', 'G', ' ', 'G', ' ', '#' },
                { '#', '#', '#', ' ', ' ', ' ', '#' },
                { ' ', ' ', '#', '#', '#', '#', '#' },
            };
            maps.Add(new MapStruct(map2, 1));

            char[,] map3 =
            {
                { '#', '#', '#', '#', '#', '#', ' ', ' ' },
                { '#', ' ', 'G', ' ', ' ', '#', ' ', ' ' },
                { '#', ' ', 'G', '#', ' ', '#', '#', '#' },
                { '#', ' ', 'P', 'B', 'B', ' ', ' ', '#' },
                { '#', ' ', 'B', 'G', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#' },
            };
            maps.Add(new MapStruct(map3, 2));
        }

        public void MapClear(int mapNumber)
        {

        }
    }
}
