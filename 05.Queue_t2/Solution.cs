using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue_t2
{
  
    public static class Solution
    {
        public static int[] solution(int[] progresses, int[] speeds)
        {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();   
            for (int i = 0; i < progresses.Length; i++)
            {
                int day = 1;
                while (progresses[i] + speeds[i] * day < 100)
                    day++;
                queue.Enqueue(day);
            }
            while (queue.Count > 0)
            {
                int sum = 0;
                int prevDay = queue.Dequeue();
                sum++;
                while (queue.Count > 0)
                {
                    if (queue.Peek() <= prevDay)
                    {
                        queue.Dequeue();
                        sum++;
                    }
                    else
                        break;
                }
                list.Add(sum);
            }
            return list.ToArray();
        }
    }
}
