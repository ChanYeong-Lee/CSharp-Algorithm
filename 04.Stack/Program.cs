namespace _04.Stack
{
    internal class Program
    {
        /**********************************************
         * 스택 (Stack)
         *                 (PIPELINE)
         * --> ┌───────────────────────────────────┐
         *     │ (Entrance/Exit)                   │
         * <-- └───────────────────────────────────┘
         * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
         * 가장 최근 입력된 순서대로 처리해야 하는 상황에 이용 
         **********************************************/

        public static void Stack()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 5; i++) 
            { 
                stack.Push(i);                      // 입력순서 : 0 1 2 3 4
            }   


            Console.WriteLine(stack.Peek());        // 최상단 : 4

            while (stack.Count > 0)
            {
                int value = stack.Pop();
                Console.WriteLine(value);     // 출력순서 : 4 3 2 1 0
            }
        }

        static void Main(string[] args)
        {
            Stack();
        }
    }
}