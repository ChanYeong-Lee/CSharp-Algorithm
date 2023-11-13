namespace _02.LinkedList
{
    internal class Program
    {
        /******************************************************************
         * 연결리스트 (Linked List)
         * 
         * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
         * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음  
         * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음 노드의 위치를 확인
         * node = (data) + (addresssOfNextNode)
         ******************************************************************/

        // <연결리스트 종류>
        // A -> B -> C -> D             : 단방향 연결리스트
        // A <-> B <-> C <-> D          : 양방향 연결리스트
        // C <- A <-> B <-> C -> A      : 환형 연결리스트 (C# uses it)

        // <연결리스트 사용>
        public static void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 연결리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("2번 뒤데이터");
            linkedList.AddLast("3번 뒤데이터");

            // 연결리스트 요소 삭제
            linkedList.Remove("2번 뒤데이터");

            // 연결리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 앞데이터");

            // 연결리스트 노드를 통한 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 연결리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 연결리스트 노드를 통한 삭제
            linkedList.Remove(findNode);
        }
        // <LinkedList 시간복잡도>
        // 접근    탐색    삽입     삭제
        // O(N)    O(N)    O(1)    O(1)

        // 이론상 이렇지만 모든 노드를 알고 있지 않는 이상 삽입, 삭제할 때 탐색부터 해야 한다.
        // 삽입, 삭제할 때마다 노드를 생성, 삭제해야 하기 때문에 가비지 컬렉터에 부담이 된다.
        // 캐시적중률 -> 컴퓨터는 연속적으로 저장된 데이터를 처리하기 빠르다.
        // 캐시메모리 -> CPU에 포함된 용량은 적지만 빠른 메모리 
        //              메모리에서 데이터를 가져올 때 자기 용량만큼 가져온다.

        public static void PrintData()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();

                int random = rand.Next() % 10;
                list.Add(random);
                linkedList.AddLast(random);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            for (LinkedListNode<int> cur = linkedList.First; cur != null; cur = cur.Next)
            {
                Console.WriteLine(cur.Value);
            }

            // <foreach 반복문>
            // 자료구조의 데이터를 처음부터 끝까지 다 출력해주는 반복문
            // Ienumerable 인터페이스를 가지고 있는 데이터이면 사용할 수    있다.
            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            foreach (int value in linkedList)
            {
                Console.WriteLine(value);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}