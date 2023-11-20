using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AlgorithmTechnique
{
    public static class Recursion
    {
        /*********************************************
         * 재귀 (Recursion)
         * 
         * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
         * (함수 호출 비용)
         * (얘는 방법론임)
         *********************************************/

        // <재귀 함수 조건>
        // 1. 함수 내용 중 자신 함수를 다시 호출해야 함
        // 2. 종료조건이 있어야 함

        // <재귀 함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4 * 3 * 2 * 1
        public static int Factorial(int x)
        {
            if (x == 1)
                return 1;

            return x * Factorial(x - 1);
        }

        private struct Directory
        {
            public string name;
            public List<Directory> childDir;
            public Directory(string name)
            {
                this.name = name;
                childDir = new List<Directory>();   
            }
        }
        private static void RemoveDir(Directory directory)
        {
            // 1번째 자식 다 지우기 
            // 2번째 자식 다 지우기 
            // ...

            foreach (Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }

            Console.WriteLine("{0}내 파일 모두 삭제",directory.name);
        }

        public static void Direc()
        {
            Directory directory = new Directory("directory");
            Directory chd1 = new Directory("ch1");
            Directory chd2 = new Directory("ch2");
            Directory chd3 = new Directory("ch3");
            Directory chd1_1 = new Directory("ch1_1");
            Directory chd2_2 = new Directory("ch2_2");
            directory.childDir.Add(chd1);
            directory.childDir.Add(chd2);
            directory.childDir.Add(chd3);
            chd1.childDir.Add(chd1_1);
            chd2.childDir.Add(chd2_2);
            RemoveDir(directory);
        }
    }
}
