using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S2
{
    public class Game
    {
        public Map map;
        public Player player;
        public UI ui;
        char[,] currentMap;
        public bool running;

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

        public void Init()
        {
            map.Init();
            currentMap = map.maps[0].map;
            SetPlayer();
        }

        public void Input()
        {

        }

        public void Update()
        {

        }

        public void Render()
        {

        }

        public void Release()
        {

        }

        public void SetPlayer()
        {
            for (int y = 0; y < currentMap.GetLength(0); y++)
            {
                for (int x = 0; x < currentMap.GetLength(1); x++)
                {
                    if (currentMap[y, x] == 'P')
                    {
                        int posX = x;
                        int posY = y;
                        player.SetPosition(posX, posY);
                    }
                }
            }

        }
        }
    }
