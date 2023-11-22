namespace _12.Searching_t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] dfsGraph = Graph.graph();
            bool[] dfsVisited;
            int[] dfsParent;

            Search.DFS(in dfsGraph, 0, out dfsVisited, out dfsParent);
            Console.Write("vertex");
            Console.Write("\t");
            Console.Write("visit");
            Console.Write("\t");
            Console.Write("parent");
            Console.WriteLine();
            for (int i = 0; i < dfsVisited.Length; i++)
            {
                Console.Write(i);
                Console.Write("\t");
                Console.Write(dfsVisited[i]);
                Console.Write("\t");
                Console.Write(dfsParent[i]);
                Console.WriteLine();
            }
            Console.WriteLine();

            bool[,] bfsGraph = Graph.graph();
            bool[] bfsVisited;
            int[] bfsParent;

            Search.BFS(in bfsGraph, 0, out bfsVisited, out bfsParent);
            Console.Write("vertex");
            Console.Write("\t");
            Console.Write("visit");
            Console.Write("\t");
            Console.Write("parent");
            Console.WriteLine();
            for (int i = 0; i < bfsVisited.Length; i++)
            {
                Console.Write(i);
                Console.Write("\t");
                Console.Write(bfsVisited[i]);
                Console.Write("\t");
                Console.Write(bfsParent[i]);
                Console.WriteLine();
            }


        }
    }
}