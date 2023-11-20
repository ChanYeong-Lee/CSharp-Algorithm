using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AlgorithmTechnique
{
    public static class Greedy
    {
        /*********************************************************
         * 탐욕 알고리즘 (Greedy Algorithm)
         * 
         * 문제를 해결하는데 사용되는 근시안(짧은시야)적 방법
         * 문제를 직면한 당시에 당장 최적인 답을 선택하는 과정을 반복
         * 단, 반드시 최적의 해를 구해준다는 보장이 없음
         *********************************************************/

        // 예시 - 자판기 거스름돈(탐욕 알고리즘이자 최적의 해)
        private static void CoinMachine(int money)
        {
            int[] coinType = { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };

            foreach (int coin in coinType)
            {
                while (money >= coin)
                {
                    Console.WriteLine("남은 돈 : {0}", money);
                    Console.WriteLine("{0} 코인 배출", coin);
                    money -= coin;
                }
            }
        }

        public static void CM()
        {
            CoinMachine(40320);
        }
    }
}
