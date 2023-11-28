using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_S3
{
    public class Game
    {
        private bool running;
        Player player;
        Map mapManager = new Map();
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
            running = true;
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


    }
}
