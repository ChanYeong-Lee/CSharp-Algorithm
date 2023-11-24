using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ShortestPath_t
{
    public class Dijkstra
    {
        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, in int start, out bool[] visited, out int[] parent, out int[] distance)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parent = new int[size];
            distance = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parent[i] = -1;
                distance[i] = INF;
            }
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                int minIndex = -1;
                int minCost = INF;

                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&              
                        distance[j] < minCost)      
                    {
                        minIndex = j;
                        minCost = distance[j];
                    }
                }
                if (minIndex < 0)                 
                    break;

                for (int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[minIndex] + graph[minIndex, j])
                    {
                        parent[j] = minIndex;
                        distance[j] = distance[minIndex] + graph[minIndex, j];
                    }
                }
                visited[minIndex] = true;
            }
        }

        public static void PrintDijkstra(bool[] visited, int[] path, int[] distance)
        {
            Console.Write(" vertex");
            Console.Write("\t");
            Console.Write("visited");
            Console.Write("\t");
            Console.Write(" parent");
            Console.Write("\t");
            Console.Write("   dist");
            Console.WriteLine();

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,7}", i);
                Console.Write("\t");
                Console.Write("{0,7}", visited[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.Write("      X");
                else
                    Console.Write("{0,7}", path[i]);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,7}", distance[i]);
                Console.WriteLine();
            }
        }
    }
}
