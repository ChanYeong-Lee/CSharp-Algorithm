namespace _02.LinkedList_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] players = { "mumu", "soe", "poe", "kai", "mine" };
            string[] callings = { "kai", "kai", "mine", "mine" };
            foreach (string value in Solution.solution(players, callings))
            {
                Console.WriteLine(value);
            }
        }
    }
}