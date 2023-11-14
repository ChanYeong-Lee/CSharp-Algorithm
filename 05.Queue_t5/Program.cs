namespace _05.Queue_t5
{
    // Programmers Lv2.주식가격
    // https://school.programmers.co.kr/learn/courses/30/lessons/42584?language=csharp

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 2, 3, 2, 3 };
            int[] answer = Solution.solution(prices);
            foreach (int i in answer)
            {
                Console.WriteLine(i);
            }
        }
    }
}