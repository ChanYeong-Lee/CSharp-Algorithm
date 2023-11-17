using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Dictionary_t
{
    internal class Game
    {
        public Player player = new Player();
        public bool invincible = false;
        public bool visible = false;
        public bool infiniteMana = false;
        public bool fastProduct = false;
        public bool checker = true;

        private static Game instance = new Game();

        private Game()
        {
            instance = this;
        }

        public static Game GetInstance()
        {
            return instance;
        }

        public void GameOver()
        {
            checker = false;
        }
        public void GameStart()
        {
            while (checker)
            {
                Console.Clear();
                ShowStatus();
                ChatInput();
            }
        }
        public void ChatInput()
        {
            Console.Write("Input CheatKey : ");
            string input = Console.ReadLine();
            if (CheatDictionary.Contains(input))
                CheatKey.Run(input);
            else if (input == "quit")
            {
                Console.WriteLine("Game Over");
                GameOver();
            }
           
        }
        public void ShowStatus()
        {
            Console.WriteLine("Mineral : {0}", player.mineral);
            Console.WriteLine("Gas : {0}", player.gas);
            Console.WriteLine("Population : {0} / {1}", player.currentPopulation, player.maxPopulation);
            if (invincible)
                Console.WriteLine("invincible : true");
            if (visible)
                Console.WriteLine("visible : true");
            if (infiniteMana)
                Console.WriteLine("infinite mana : true");
            if (fastProduct)
                Console.WriteLine("fastProduct : true");
        }
    }
}
