namespace _05.Queue_t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] progresses = { 95, 90, 99, 99, 80, 99 };
            int[] speeds = { 1, 1, 1, 1, 1, 1};
            int[] array = Solution.solution(progresses, speeds);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}