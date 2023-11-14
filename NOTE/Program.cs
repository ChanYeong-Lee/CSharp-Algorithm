namespace NOTE
{
    internal class Program
    {
        public class Solution
        {
            public int[] solution(int[] numbers, int num1, int num2)
            {
                int[] answer = new int[num2 - num1 + 1];
                int a = 0;
                for (int i = num1; i <= num2; i++)
                {
                   answer[a] =numbers[i] ;
                    a++;
                }
                return answer;
            }
        }

        static void Main(string[] args)
        {
            char[] answer =
            Solution solution = new Solution();
            int[] array = new int[3];
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
                array=solution.solution(numbers,1,3);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}