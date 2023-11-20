using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AlgorithmTechnique
{
    public static class DynamicProgramming
    {
        /****************************************************************************
         * 동적 계획법 (Dynamic Programming)
         * 
         * 작은 문제의 해답을 큰 문제의 해답의 부분으로 이용하는 상향식 접근 방식
         * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법 
         ****************************************************************************/

        // 예시 - 피보나치 수열
        static int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];

            if (x == 1 || x == 2)
                return 1;
            else
            {
                fibonachi[1] = 1;
                fibonachi[2] = 1;

                for (int i = 3; i <= x; i++)
                {
                    fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
                }

                return fibonachi[x];
            }
        }

        // (피보나치를 재귀로 한다면...)
        // inf Fibnachi(int x)
        // {
        //     if (x == 1 || x == 2)
        //         return 1;
        //     return Fibonachi[x-1] + Fibonachi[x-2];
        // }
        // (숫자가 늘어날 수록 기하급수적으로 함수호출 횟수가 늘어난다.)
        public static void Fib()
        {
            for (int i = 1; i < 31; i++)
            {
                Console.WriteLine(Fibonachi(i));
            }
        }
    }
}
