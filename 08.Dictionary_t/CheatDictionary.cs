using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Dictionary_t
{
    internal static class CheatDictionary
    {
        public static Dictionary<string, Action> cheatDic = new Dictionary<string, Action>()
        {
            {"show me the money", CheatKey.ShowMeTheMoney },
            {"there is no cow level", CheatKey.ThereIsNoCowLevel },
            {"operation cwal", CheatKey.OperationCwal },
            {"black sheep wall", CheatKey.BlackSheepWall },
            {"power overwhelming", CheatKey.PowerOverWhelming },
            {"food for thought", CheatKey.FoodForThought },
            {"the gathering", CheatKey.TheGathering },
        };

        public static Action FindCheat(string cheat)
        {
            if (cheatDic.ContainsKey(cheat))            // 예외처리   
            {
                return cheatDic[cheat];
            }
            else
                return NullFunction;
        }

        public static bool Contains(string cheat)
        {
            return cheatDic.ContainsKey(cheat);
        }

        public static void NullFunction()
        {
        }

    }
}
