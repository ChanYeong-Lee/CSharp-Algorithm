using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _12.Searching_t2
{
    internal class Search
    {
        public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            Stack<int> dfsStack = new Stack<int>(); 
            dfsStack.Push(start);
            while (dfsStack.Count > 0)
            {
                int next = dfsStack.Peek();
                visited[next] = true;
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i])
                    {
                        parent[i] = next;
                        dfsStack.Push(i);
                        break;
                    }
                }
                if(next==dfsStack.Peek())
                {
                    dfsStack.Pop();
                }
            }
        }

        public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();
            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i])
                    {
                        parent[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
