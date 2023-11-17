using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Dictionary_t
{
    internal static class CheatKey
    {
        public static Action runCheat;
        public static void Run(string cheat)
        {
            runCheat = CheatDictionary.FindCheat(cheat);
            runCheat();
        }

        public static void ShowMeTheMoney()
        {
            Game.GetInstance().player.mineral += 10000;
            Game.GetInstance().player.gas += 10000;
        }

        public static void ThereIsNoCowLevel()
        {
            Console.WriteLine("You Win.");
            Game.GetInstance().checker = false;
        }

        public static void OperationCwal()
        {
            if (Game.GetInstance().fastProduct == true)
                Game.GetInstance().fastProduct = false;
            else
                Game.GetInstance().fastProduct = true;
        }

        public static void BlackSheepWall()
        {
            if (Game.GetInstance().visible == true)
                Game.GetInstance().visible = false;
            else
                Game.GetInstance().visible = true;
        }
        
        public static void PowerOverWhelming()
        {
            if (Game.GetInstance().invincible == true)
                Game.GetInstance().invincible = false;
            else
                Game.GetInstance().invincible = true;
        }
        
        public static void FoodForThought()
        {
            Game.GetInstance().player.maxPopulation = 200;
        }

        public static void TheGathering()
        {
            if (Game.GetInstance().infiniteMana == true)
                Game.GetInstance().infiniteMana = false;
            else
                Game.GetInstance().infiniteMana = true;
        }
    }
}
