using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S2
{
    public class Player
    {
        public int posX;
        public int posY;
        public Stack<Data> data = new Stack<Data>();
        public void SetPosition(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void Move(ConsoleKeyInfo input)
        {
            switch(input.Key)
            {
                case ConsoleKey.UpArrow:
                    posY--;
                    break;

                case ConsoleKey.DownArrow:
                    posY++;
                    break;

                case ConsoleKey.RightArrow:
                    posX++;
                    break;
                
                case ConsoleKey.LeftArrow: 
                    posX--;
                    break;

                default:
                    return;
            }
        }
    }
}
