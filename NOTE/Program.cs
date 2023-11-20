namespace NOTE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = new char[3] { 'a', 'b', 'c' };
            string my_string = "helloworld";
            Solution solution = new Solution();
            Console.Write(solution.solution(my_string));
        }
    }
}
