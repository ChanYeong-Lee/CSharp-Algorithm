using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Searching
{
    internal class Search
    {
        // <순차 탐색>
        // 시간복잡도 - O(N)
        public static int SequentialSearch<T>(IList<T> list, T item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // <이진 탐색>
        // 시간복잡도 - O(logN)
        // 정렬이 안되어 있으면 사용 불가
        public static int BinarySearch<T>(IList<T> list, T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1;
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;
        }

        // <깊이 우선 탐색 (DFS : Depth-First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 분할 정복
        // 스택을 이용하여 구현 (함수호출스택, 즉 재귀함수)
        // 최단경로가 아닐수도 있음
        public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] path)
        {
            visited = new bool[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                path[i] = -1;
            }

            SearchNode(graph, start, visited, path);
        }

        private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] path)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] &&  // 연결되어 있는 정점이며,
                    !visited[i])        // 방문한 적 없는 정점
                {
                    path[i] = start;
                    SearchNode(graph, i, visited, path);
                }
            }
        }

        // <너비 우선 탐색 (BFS : Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기를 한번씩 탐색한 뒤
        // 다음 깊이를 탐색하는 방식
        // 큐를 이용하여 구현
        // 반드시 최단경로가 나옴
        public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] path)
        {
            visited = new bool[graph.GetLength(0)];
            path = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                path[i] = -1;
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
                        path[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
