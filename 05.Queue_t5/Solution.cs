using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue_t5
{
    internal static class Solution
    {
        public static int[] solution(int[] prices)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < prices.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < prices.Length; j++)
                {
                    if (prices[i] <= prices[j])
                    {
                        sum++;
                        if (j == prices.Length - 1)
                            sum--;
                    }
                    else
                        break;
                    
                }
                queue.Enqueue(sum);
            }
            return queue.ToArray();
        }
    }
}
