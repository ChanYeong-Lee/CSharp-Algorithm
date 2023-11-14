namespace _05.Queue_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "()()";
            string s2 = "(())()";
            string s3 = ")()(";
            string s4 = "(()(";

            Console.WriteLine(Solution.solution(s1));
            Console.WriteLine(Solution.solution(s2));
            Console.WriteLine(Solution.solution(s3));
            Console.WriteLine(Solution.solution(s4));
        }
    }
}