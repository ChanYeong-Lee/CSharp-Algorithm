namespace NOTE
{
    internal class Program
    {
        static void PrintEdge<T>(T[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void AddEdge<T>(T[,] map, int v1, int v2, T val)
        {
            map[v1, v2] = val;
            map[v2, v1] = val;
        }
        static void AddSingleEdge<T>(T[,] map, int start, int dest, T val)
        {
            map[start, dest] = val;
        }
        static List<int> dfs(bool[,] map, int startPos)
        {
            List<int> answer = new List<int>();
            Stack<int> stack = new Stack<int>();
            bool[] visit = new bool[map.GetLength(0)];
            stack.Push(startPos);

            while (stack.Count > 0)
            {
                int pos = stack.Pop();
                if (visit[pos] == true)
                {
                    continue;
                }
                visit[pos] = true;
                answer.Add(pos);

                for (int i = map.GetLength(0) - 1; i >= 0; i--)
                {
                    if (map[pos, i] != false && !visit[i])
                    {
                        stack.Push(i);
                    }
                }
            }

            return answer;
        }
        static List<int> bfs(bool[,] map, int startPos)
        {
            List<int> answer = new List<int>();
            Queue<int> queue = new Queue<int>();
            bool[] visit = new bool[map.GetLength(0)];
            queue.Enqueue(startPos);
            visit[startPos] = true;

            while (queue.Count > 0)
            {
                int pos = queue.Dequeue();
                answer.Add(pos);

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    if (map[pos, i] != false && !visit[i])
                    {
                        queue.Enqueue(i);
                        visit[i] = true;
                    }
                }
            }

            return answer;
        }
        static void Main(string[] args)
        {
            const int N = 8;
            bool[,] map = new bool[N, N];
            AddEdge<bool>(map, 0, 3, true);
            AddEdge<bool>(map, 0, 4, true);
            AddEdge<bool>(map, 1, 3, true);
            AddEdge<bool>(map, 1, 5, true);
            AddEdge<bool>(map, 1, 6, true);
            AddEdge<bool>(map, 2, 6, true);
            AddEdge<bool>(map, 3, 5, true);
            AddEdge<bool>(map, 3, 7, true);
            AddEdge<bool>(map, 4, 6, true);
            AddEdge<bool>(map, 5, 6, true);
            AddEdge<bool>(map, 5, 7, true);
            AddEdge<bool>(map, 6, 7, true);
            //PrintEdge<bool>(map);

            List<int> seq;
            //seq = dfs(map, 0);
            //03156247(숫자가 작은 정점을 먼저 방문)

            seq = bfs(map, 0);
            //03415762

            foreach (int i in seq)
            {
                Console.Write(i);
            }
        }
    }
}