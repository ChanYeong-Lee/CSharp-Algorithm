namespace _14.PathFinding_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] tileMap = new bool[8, 9]
                        {
                { false, false, false, false, false, false, false , false , false },
                { false,  true,  true,  true,  true,  true,  true ,  true , false },
                { false,  true,  true,  true, false,  true,  true ,  true , false },
                { false,  true,  true,  true, false,  true,  true ,  true , false },
                { false,  true,  true,  true, false,  true,  true ,  true , false },
                { false,  true,  true,  true, false,  true,  true ,  true , false },
                { false,  true,  true,  true,  true,  true,  true ,  true , false },
                { false, false, false, false, false, false, false , false , false },
                        };
            List<AStar.Point> path;
            bool[,] visited;

            AStar.PathFinding(tileMap, new AStar.Point(2, 5), new AStar.Point(6, 3), false, out path, out visited, "Manhattan");
            PrintResult(tileMap, path);
            Console.WriteLine();
            PrintVisited(visited);
        }
        static void PrintResult(in bool[,] tileMap, in List<AStar.Point> path)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
            Console.WriteLine("Path");
            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x])
                        pathMap[y, x] = ' ';
                    else
                        pathMap[y, x] = 'X';
                }
            }

            foreach (AStar.Point point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            AStar.Point start = path.First();
            AStar.Point end = path.Last();
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int j = 0; j < pathMap.GetLength(1); j++)
                {
                    Console.Write(pathMap[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintVisited(bool[,] visited)
        {
            Console.WriteLine("Visited");
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    if (visited[i, j])
                        Console.Write("O");
                    else
                        Console.Write("X");
                }
                Console.WriteLine();
            }
        }
    }
}