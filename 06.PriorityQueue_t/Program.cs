using System.Collections.Generic;

namespace _06.PriorityQueue_t
{
    // Baekjoon 가운데를 말해요
    // https://www.acmicpc.net/problem/1655

    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int, int> pqP = new PriorityQueue<int, int>();
            PriorityQueue<int, int> pqM = new PriorityQueue<int, int>();

           
            int amount = int.Parse(Console.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    pqP.Enqueue(input, input);
                    pqM.Enqueue(input, -input);
                    Console.WriteLine(pqP.Peek());
                }
                if (i % 2 == 1)
                {
                    if (input > pqM.Peek())
                    {
                        pqP.Enqueue(input, input);
                        pqM.Dequeue();
                        pqM.Enqueue(pqP.Peek(), -pqP.Dequeue());
                        Console.WriteLine(pqM.Peek());
                    }
                    else
                    {
                        pqP.Enqueue(pqM.Peek(), pqM.Dequeue());
                        pqM.Enqueue(input, -input);
                        Console.WriteLine(pqM.Peek());

                    }

                }
            }
        }
    }
}


// Input : 7, 1, 5, 2, 10, -99, 7, 5
// Output : 1, 1, 2, 2, 2, 2, 5