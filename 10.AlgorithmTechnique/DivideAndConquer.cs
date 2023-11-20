using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AlgorithmTechnique
{
    public static class DivideAndConquer
    {
        /*******************************************************************
         * 분할정복 (Divide and Conquer)
         * 
         * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
         * 분할을 통해 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
         *******************************************************************/

        // 예시 1 - 거듭 제곱 계산
        private static int Pow(int x, int n)
        {
            // x^n = (x * x)^(n / 2)

            if (n == 0)
                return 1;

            int result;
            if (n % 2 == 0)
                result = Pow(x * x, n / 2);
            else
                result = x * Pow(x*x, (n - 1) / 2);
            return result;
        }


        // 예시 2 - 폴더 삭제
        struct Directory
        {
            public List<Directory> childDir;
        }

        static void RemoveDir(Directory directory)
        {
            foreach (Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("폴더 내 모든 파일 삭제");
        }

        public static void PowTest()
        {
            Console.WriteLine(Pow(2, 3));
        }
    }
}
