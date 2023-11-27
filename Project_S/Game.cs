using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_S
{
    public class Game
    {
        enum MoveDir { Up, Down, Left, Right, None, U }
        private bool running = true;

        private int playerPosX = 1;
        private int playerPosY = 1;

        private MoveDir input;

        private Map maps = new Map();
        private char[,] currentMap;
        private int mapNumber = 0;

        private Stack<char[,]> moves = new Stack<char[,]>();

        public void Run()
        {
            Init();

            while (running)
            {
                Input();
                Update();
                Render();
            }

            Release();
        }

        private void Init()
        {
            Console.Title = "Project-S";
            Console.CursorVisible = false;

            SetMap();
            Render();
        }

        private void Release()
        {
            Console.Clear();
            Console.WriteLine("Game Clear!");
        }

        private void Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            ConsoleKey key = info.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    input = MoveDir.Up;
                    break;
                case ConsoleKey.DownArrow:
                    input = MoveDir.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    input = MoveDir.Left;
                    break;
                case ConsoleKey.RightArrow:
                    input = MoveDir.Right;
                    break;
                case ConsoleKey.R:
                    input = MoveDir.None;
                    SetMap();
                    break;
                case ConsoleKey.D1:
                    mapNumber = 0;
                    input = MoveDir.None;
                    SetMap();
                    break;
                case ConsoleKey.D2:
                    mapNumber = 1;
                    input = MoveDir.None;
                    SetMap();
                    break;
                case ConsoleKey.D3:
                    mapNumber = 2;
                    input = MoveDir.None;
                    SetMap();
                    break;
                default:
                    input = MoveDir.None;
                    break;
            }
        }

        private void Update()
        {
            int prevPosX = playerPosX;
            int prevPosY = playerPosY;
            // 플레이어 이동
            switch (input)
            {
                case MoveDir.Up:
                    playerPosY--;
                    break;
                case MoveDir.Down:
                    playerPosY++;
                    break;
                case MoveDir.Left:
                    playerPosX--;
                    break;
                case MoveDir.Right:
                    playerPosX++;
                    break;
                case MoveDir.None:
                    break;
                default:
                    break;
            }

            // 이동한 자리가 벽일 경우
            if (currentMap[playerPosY, playerPosX] == '#')
            {
                playerPosX = prevPosX;
                playerPosY = prevPosY;
            }

            // 이동한 자리가 박스일 경우
            else if (currentMap[playerPosY, playerPosX] == 'B')
            {
                int nextPosX = 0;
                int nextPosY = 0;

                switch (input)
                {
                    case MoveDir.Up:
                        nextPosX = playerPosX;
                        nextPosY = playerPosY - 1;
                        break;
                    case MoveDir.Down:
                        nextPosX = playerPosX;
                        nextPosY = playerPosY + 1;
                        break;
                    case MoveDir.Left:
                        nextPosX = playerPosX - 1;
                        nextPosY = playerPosY;
                        break;
                    case MoveDir.Right:
                        nextPosX = playerPosX + 1;
                        nextPosY = playerPosY;
                        break;
                }

                // 박스의 위치가 빈공간인 경우
                if (currentMap[nextPosY, nextPosX] == ' ')
                {
                    currentMap[nextPosY, nextPosX] = 'B';
                    currentMap[playerPosY, playerPosX] = ' ';
                }

                // 박스의 위치가 골인 경우
                else if (currentMap[nextPosY, nextPosX] == 'G')
                {
                    currentMap[nextPosY, nextPosX] = 'O';
                    currentMap[playerPosY, playerPosX] = ' ';
                }
                else
                {
                    playerPosX = prevPosX;
                    playerPosY = prevPosY;
                }
            }

            // 이동한 자리가 골 위에 박스인 경우
            else if (currentMap[playerPosY, playerPosX] == 'O')
            {
                int nextPosX = 0;
                int nextPosY = 0;

                switch (input)
                {
                    case MoveDir.Up:
                        nextPosX = playerPosX;
                        nextPosY = playerPosY - 1;
                        break;
                    case MoveDir.Down:
                        nextPosX = playerPosX;
                        nextPosY = playerPosY + 1;
                        break;
                    case MoveDir.Left:
                        nextPosX = playerPosX - 1;
                        nextPosY = playerPosY;
                        break;
                    case MoveDir.Right:
                        nextPosX = playerPosX + 1;
                        nextPosY = playerPosY;
                        break;
                }

                // 이동한 위치가 빈공간인 경우
                if (currentMap[nextPosY, nextPosX] == ' ')
                {
                    currentMap[nextPosY, nextPosX] = 'B';
                    currentMap[playerPosY, playerPosX] = 'G';
                }

                // 이동한 위치가 골인 경우
                else if (currentMap[nextPosY, nextPosX] == 'G')
                {
                    currentMap[nextPosY, nextPosX] = 'O';
                    currentMap[playerPosY, playerPosX] = 'G';
                }
                else
                {
                    playerPosX = prevPosX;
                    playerPosY = prevPosY;
                }
            }

            // 이동을 마친 후 승리조건을 달생했을 경우
            int goalCount = 0;
            for (int y = 0; y < currentMap.GetLength(0); y++)
            {
                for (int x = 0; x < currentMap.GetLength(1); x++)
                {
                    if (currentMap[y, x] == 'G')
                    {
                        goalCount++;
                    }
                }
            }

            if (goalCount == 0)
            {
                maps.mapList[mapNumber].clear = true;
                if (Clear())
                {
                    running = false;
                }
                else
                {
                    mapNumber++;
                    SetMap();
                }
            }
        }

        private bool Clear()
        {
            for (int i = 0; i < maps.mapList.Count; i++)
            {
                if (maps.mapList[i].clear)
                    continue;
                else
                    return false;
            }
            return true;
        }

        private void Render()
        {
            Console.Clear();

            for (int y = 0; y < currentMap.GetLength(0); y++)
            {
                for (int x = 0; x < currentMap.GetLength(1); x++)
                {
                    Console.Write(currentMap[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(moves.Count);

            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.Write("P");
        }

        private void SetInitialPosition()
        {
            for (int y = 0; y < currentMap.GetLength(0); y++)
            {
                for (int x = 0; x < currentMap.GetLength(1); x++)
                {
                    if (currentMap[y, x] == 'P')
                    {
                        playerPosX = x;
                        playerPosY = y;
                        currentMap[y, x] = ' ';
                    }
                }
            }
        }

        private void SetMap()
        {
            currentMap = (char[,])maps.mapList[mapNumber].map.Clone();
            SetInitialPosition();
        }
    }
}
