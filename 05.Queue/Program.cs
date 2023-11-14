namespace _05.Queue
{
    internal class Program
    {
        /***********************************************
         * 큐 (Queue)
         *                 (PIPELINE)
         *     ┌─────────────────────────────────┐
         * <-- │ (Exit)               (Entrance) │ <--
         *     └─────────────────────────────────┘
         * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
         * 입력된 순서대로 처리해야 하는 상황에 이용
         ***********************************************/


        public static void Queue()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);           // 입력순서 : 0, 1, 2, 3, 4, 5, 6, 7, 8 ,9
            }

            while (queue.Count > 0)
            {
                int value = queue.Dequeue();
                Console.WriteLine(value);   // 출력순서 : 0, 1, 2, 3, 4, 5, 6, 7, 8 ,9
            }
        }

        static void Main(string[] args)
        {
        }
    }
}