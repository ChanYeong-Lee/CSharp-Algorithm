using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PriorityQueue_t2
{
    internal static class Solution
    {
        public static int solution(int[,] jobs)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            Queue<int> process = new Queue<int>();
            Queue<int> finish = new Queue<int>();
            int count = 0;
            int sum = 0;
            while (finish.Count < jobs.GetLength(0))
            {
                for (int i = 0; i < jobs.GetLength(0); i++) // 이 시간에 요청되는 작업 찾기
                {
                    if (count == jobs[i, 0])
                    {
                        minHeap.Enqueue(jobs[i, 1], jobs[i, 1]);    // 우선순위 큐에 집어넣기
                    }

                }
                if (minHeap.Count != 0&&process.Count==0)   // 작업 큐가 비어있을때
                {
                    for (int i = 0; i < minHeap.Peek(); i++)
                    {
                        process.Enqueue(1);                 // 소요시간만큼 1을 Enqueue
                    }
                    minHeap.Dequeue();                      // 우선순위 큐에서 내보내기
                }
                if (process.Count != 0)                      // 작업 중 초당 1개씩 내보내기
                {
                    process.Dequeue();
                    if (process.Count == 0)
                    {
                        finish.Enqueue(1);
                    }
                }
                if (minHeap.Count != 0)
                {
                    sum += minHeap.Count;                   // 현재 대기중인 작업*1초
                }
                count++;                                    // 1초 흘리기
            }


            return (count + sum)/ jobs.GetLength(0);
        }
    }
}
