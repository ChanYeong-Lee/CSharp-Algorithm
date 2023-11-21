using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _10.AlgorithmTechnique_t2
{
    public class HanoiTower
    {
        List<Stack<int>> stacks = new List<Stack<int>>();
        Stack<int> stack0 = new Stack<int>();
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public HanoiTower(int num)
        {
            stacks.Add(stack0);
            stacks.Add(stack1);
            stacks.Add(stack2);
            for (int i = 0; i < num; i++)
            {
                stacks[0].Push(i);
            }

        }
        
        public void Move(int start, int end, int n)
        {
            int other = 3 - start - end;
            if (n == 1)
            {
                int value = stacks[start].Pop();
                stacks[end].Push(value);
                Console.WriteLine("{0}번 기둥에서 {1}번 기둥으로 {2} 원판을 옮깁니다.", start+1, end+1, value);
            }
            else
            {
                Move(start, other, n - 1);
                Move(start, end, 1);
                Move(other, end, n - 1);
            }
        }
    }
}
