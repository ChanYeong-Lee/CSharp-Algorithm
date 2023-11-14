namespace _05.Queue_t4
{
    // Programmers Lv2.다리를 지나는 트럭
    // https://school.programmers.co.kr/learn/courses/30/lessons/42583?language=csharp
    internal class Program
    {
        static void Main(string[] args)
        {
            int bridge_length = 100;
            int weight = 100;
            int[] truck_weights = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            int res = Solution.solution(bridge_length, weight, truck_weights);  
            Console.WriteLine(res);
        }
    }
}