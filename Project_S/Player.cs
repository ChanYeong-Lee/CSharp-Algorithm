using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S
{
    internal class Player
    {
        public int posX;
        public int posY;

        public void Move(ConsoleKeyInfo input)
        {
            ConsoleKey key = input.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    posY--;
                    break;
                case ConsoleKey.DownArrow:
                    posY++;
                    break;
                case ConsoleKey.LeftArrow:
                    posX--;
                    break;
                case ConsoleKey.RightArrow:
                    posX++;
                    break;
            }
        }
    }
}
