using System.Collections.Generic;
using System.Text;

namespace _06.PriorityQueue_t
{
    // Baekjoon 가운데를 말해요
    // https://www.acmicpc.net/problem/1655

    internal class Program
    {


        public static PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();
        public static PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        public static void maxtomin(int a)
        {
            minHeap.Enqueue(maxHeap.Peek(), maxHeap.Peek());
            maxHeap.Dequeue();
            maxHeap.Enqueue(a, -a);
        }
        public static void mintomax(int a)
        {
            maxHeap.Enqueue(minHeap.Peek(), -minHeap.Peek());
            minHeap.Dequeue();
            minHeap.Enqueue(a, a);
        }
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int t;
            t = int.Parse(Console.ReadLine());
            int a;

            for (int i = 1; i <= t; i++)
            {
                a = int.Parse(Console.ReadLine());
                if (maxHeap.Count == 0)
                {
                    maxHeap.Enqueue(a, -a);
                }
                else if (minHeap.Count == 0)
                {
                    if (maxHeap.Peek() > a) maxtomin(a);
                    else minHeap.Enqueue(a, a);
                }
                else if (minHeap.Count > maxHeap.Count)
                {
                    if (minHeap.Peek() > a) maxHeap.Enqueue(a, -a);
                    else mintomax(a);
                }
                else if (maxHeap.Count > minHeap.Count)
                {
                    if (maxHeap.Peek() >= a) maxtomin(a);
                    else minHeap.Enqueue(a, a);
                }
                else
                { //둘의 사이즈가 같다
                    if (minHeap.Peek() > a) maxHeap.Enqueue(a, -a);
                    else mintomax(a);
                }
                sb.AppendLine(maxHeap.Peek().ToString());
            }
            Console.Write(sb);
        }
    }
}




// Input : 7, 1, 5, 2, 10, -99, 7, 5
// Output : 1, 1, 2, 2, 2, 2, 5