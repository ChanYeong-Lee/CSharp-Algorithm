namespace _12.Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 순차탐색
            int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            int sequentialIndex = Search.SequentialSearch(array, 2);
            Console.Write("순차탐색 배열 : ");
            foreach (int i in array) Console.Write("{0} ", i);
            Console.WriteLine("순차탐색 결과 위치 : {0}", sequentialIndex);

            // 이진탐색
            Array.Sort(array);  // 이진탐색의 경우 우선 정렬이 필요
            int binaryIndex = Search.BinarySearch(array, 2);
            Console.Write("이진탐색 배열 : ");
            foreach (int i in array) Console.Write("{0} ", i);
            Console.WriteLine("이진탐색 결과 위치 : {0}", binaryIndex);

            Console.WriteLine();

            // 그래프 탐색
            bool[,] graph = new bool[8, 8]
            {
                { false,  true, false, false, false, false, false, false },
                {  true, false,  true, false, false,  true, false, false },
                { false,  true, false, false,  true,  true, false, false },
                { false, false, false, false, false,  true, false, false },
                { false, false,  true, false, false, false,  true,  true },
                { false,  true,  true,  true, false, false, false, false },
                { false, false, false, false,  true, false, false, false },
                { false, false, false, false,  true, false, false, false },
            };

            // DFS 탐색
            bool[] dfsVisited;
            int[] dfsPath;
            Search.DFS(in graph, 0, out dfsVisited, out dfsPath);
            Console.WriteLine("<DFS>");
            PrintGraphSearch(dfsVisited, dfsPath);
            Console.WriteLine();

            // BFS 탐색
            bool[] bfsVisited;
            int[] bfsPath;
            Search.BFS(in graph, 0, out bfsVisited, out bfsPath);
            Console.WriteLine("<BFS>");
            PrintGraphSearch(bfsVisited, bfsPath);
            Console.WriteLine();
        }

        private static void PrintGraphSearch(bool[] visited, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("Visit");
            Console.Write("\t");
            Console.WriteLine("Path");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(i);
                Console.Write("\t");
                Console.Write(visited[i]);
                Console.Write("\t");
                Console.WriteLine(path[i]);
            }
        }
    }
}