using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S2
{
    public class UI
    {
        public void Draw(Player player, char[,] map)
        {
            DrawMap(map);
            DrawPlayer(player);
            DrawStatus(player);
        }
        public void DrawStatus(Player player)
        {
            Console.WriteLine(player.data.Count);
        }

        public void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }

        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.posX, player.posY);
            Console.Write('P');
        }
    }
}
