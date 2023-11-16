namespace _06.PriorityQueue_t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] jobs = { { 0, 3 }, { 1, 9 }, { 2, 6 } };
            int answer = Solution.solution(jobs);
            Console.WriteLine(answer);
        }
    }
}