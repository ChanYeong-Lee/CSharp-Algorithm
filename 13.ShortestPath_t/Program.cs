namespace _13.ShortestPath_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int INF = 99999;
            int[,] graph = new int[8, 8]
            {
                {   0,   6,   3,   7,   3, INF, INF, INF},
                {   6,   0,   5, INF, INF,   6,   2, INF},
                {   3,   5,   0, INF, INF, INF,   3, INF},
                {   7, INF, INF,   0, INF, INF, INF, INF},
                {   3, INF, INF, INF,   0, INF, INF, INF},
                { INF,   6, INF, INF, INF,   0, INF,   5},
                { INF,   2,   3, INF, INF, INF,   0,   2},
                { INF, INF, INF, INF, INF,   5,   2,   0},
            };

            bool[] dijkstraVisited;
            int[] dijkstraParent;
            int[] dijkstraDistance;
            Dijkstra.ShortestPath
                (
                in graph,
                0,
                out dijkstraVisited,
                out dijkstraParent,
                out dijkstraDistance
                );
            Console.WriteLine("<Dijkstra>");
            Dijkstra.PrintDijkstra(dijkstraVisited, dijkstraParent, dijkstraDistance);
        }
    }
}