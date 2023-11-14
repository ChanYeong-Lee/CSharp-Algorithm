namespace _05.Queue_t3
{
    // Programmers Lv2.프로세스
    // https://school.programmers.co.kr/learn/courses/30/lessons/42587
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] priorities = { 1, 1, 9, 1, 1, 1 } ;
            int location = 0;
            int result = Solution.solution(priorities, location);
            Console.WriteLine(result);
        }
    }
}