using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ShortestPath
{
    internal class FloydWarshall
    {
        /*************************************************************
         * 플로이드-워셜 알고리즘 (Floyd-Warshall Algorithm)
         * 
         * 모든 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         * 모든 노드를 거쳐가며 최단 거리가 갱신되는 조합이 있을 경우 갱신
         *************************************************************/

        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, out int[,] costTable, out int[,] pathTable)
        {
            int count = graph.GetLength(0);
            costTable = new int[count, count];
            pathTable = new int[count, count];

            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < count; x++)
                {
                    costTable[y, x] = graph[y, x];
                    pathTable[y, x] = -1;
                }
            }

            for (int middle = 0; middle < count; middle++)
            {
                for (int start = 0; start < count; start++)
                {
                    for (int end = 0; end < count; end++)
                    {
                        if (costTable[start, end] > costTable[start, middle] + costTable[middle, end])
                        {
                            costTable[start, end] = costTable[start, middle] + costTable[middle, end];
                            pathTable[start, end] = middle;
                        }
                    }
                }
            }
        }
        public static void PrintFloydWarshall(int[,] costTable, int[,] pathTable)
        {
            Console.WriteLine("Cost table");
            for (int y = 0; y < costTable.GetLength(0); y++)
            {
                for (int x = 0; x < costTable.GetLength(1); x++)
                {
                    if (costTable[y, x] >= INF)
                        Console.Write("INF ");
                    else
                        Console.Write("{0,3} ", costTable[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Path table");
            for (int y = 0; y < pathTable.GetLength(0); y++)
            {
                for (int x = 0; x < pathTable.GetLength(1); x++)
                {
                    if (pathTable[y, x] < 0)
                        Console.Write("  X ");
                    else
                        Console.Write("{0,3} ", pathTable[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
