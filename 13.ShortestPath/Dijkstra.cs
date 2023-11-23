using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ShortestPath
{
    internal class Dijkstra
    {
        /****************************************************************
         * 다익스트라 알고리즘 (Dijkstra Algorithm)
         * 
         * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
         ****************************************************************/

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

                // 1. 탐색하지 않은 정점 중 가장 가까운 정점부터 탐색
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&              // 탐색하지 않았으면서
                        distance[j] < minCost)      // 가장 가까운 정점
                    {
                        minIndex = j;
                        minCost = distance[j];
                    }
                }
                if (minIndex < 0)                   // 더이상 탐색할 정점이 없는 경우
                    break;

                // 2. 탐색된 노드를 거쳐간 거리가 직접 연결된 거리보다 짧아지면 갱신
                for (int j = 0; j < size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[minIndex] : 현재 탐색중인 노드까지의 거리
                    // graph[minIndex, j] : 현재 탐색중인 노드부터 목적지까지의 거리 
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
