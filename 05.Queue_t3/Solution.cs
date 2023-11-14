using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue_t3
{
    public static class Solution
    {
        public static int solution(int[] priorities, int location)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < priorities.Length; i++)
            {
                queue.Enqueue(i);
            }
            while (queue.Count > 0)
            {
                int process = queue.Dequeue();
                int count = queue.Count();
                for (int i = 0; i < priorities.Length; i++)
                {
                    if (priorities[process] < priorities[i])
                    {
                        queue.Enqueue(process);
                        break;
                    }
                }
                if (count == queue.Count())
                {
                    priorities[process] = 0;
                    if (location == process)
                    {
                        return priorities.Length - queue.Count();
                    }
                }
            }
                return 0;
        }
    }
}
