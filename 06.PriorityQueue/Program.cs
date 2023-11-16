namespace _06.PriorityQueue
{
    internal class Program
    {
        public static void PQ()
        {
            MyPriorityQueue<string, int> pq = new MyPriorityQueue<string, int>();   // 비교 기준이 String, Char이면 사전에서 빠른 순, enum class도 가능
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("슬라임");
            queue.Enqueue("드래곤");
            queue.Enqueue("오크");
            queue.Enqueue("고블린");

            while (queue.Count > 0)
            {
                string monsterName = queue.Dequeue();
                Console.WriteLine(monsterName);
            }
            Console.WriteLine();
            
            pq.Enqueue("슬라임", 1);
            pq.Enqueue("드래곤", 100);
            pq.Enqueue("오크", 20);
            pq.Enqueue("고블린", 50);

            while (pq.Count > 0) 
            {
                string monsterName = pq.Dequeue();          // 기본적으로 오름차순
                Console.WriteLine(monsterName);
            }
            Console.WriteLine();

            MyPriorityQueue<string, int> pq2 = new MyPriorityQueue<string, int>();
            pq2.Enqueue("슬라임", -1);
            pq2.Enqueue("드래곤", -100);
            pq2.Enqueue("오크", -20);
            pq2.Enqueue("고블린", -50);

            while (pq2.Count > 0)
            {
                string monsterName = pq2.Dequeue();         // 수치에 -를 곱해서 내림차순으로
                Console.WriteLine(monsterName);
            }
        }
        // 주의!
        // 우선순위 큐는 Enqueue할 때 우선순위를 판단하기 때문에 이미 queue 안에 들어 있는
        // 변수의 우선순위를 바꾼다고 해서 Dequeue 순서가 바뀌지는 않는다.

        // <우선순위 큐 시간복잡도>
        // 최우선순위 데이터 확인     추가      삭제
        //         O(1)            O(logN)  O(logN)

        // 배열기반이었을 경우
        // 최우선순위 데이터 확인     추가      삭제
        //         O(1)             O(N)      O(N)

        // 단점!
        // 캐시 적중률이 안좋다.
        // 인덱스를 1, 3, 7, 15, 31 이런식으로 써야되서...
        
        static void Main(string[] args)
        {
            PQ();
        }
    }
}