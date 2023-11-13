namespace _02.LinkedList
{
    public class MyLinkedList<T>
    {
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;
        private int count;
        
        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public MyLinkedListNode<T> First { get { return head; } } 
        public MyLinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public MyLinkedListNode<T> AddFirst(T value)
        {                                  // 새로운 노드 생성
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);   

            if (count > 0)                 // 다른 노드가 있었던 상황
            {
                newNode.next = head;       // 새 노드 다음 노드를 헤드
                head.prev = newNode;       // 헤드의 전 노드가 새 노드
                head = newNode;            // 새 노드가 헤드
            }
            else                           // 처음으로 추가하는 상황
            {
                head = newNode;
                tail = newNode;
            }

            count++;
            return newNode;
        }

        public MyLinkedListNode<T> AddLast(T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);

            if (count > 0)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }

            count++;
            return newNode;
        }

        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T> current = head;

            // 객체끼리는 비교 불가하니까 이 메소드 사용
            EqualityComparer<T> comparer = EqualityComparer<T>.Default; 

            while (current != null)
            {
                if (comparer.Equals(current.Item, value))
                {
                    return current;
                }
                else
                {
                    current = current.Next;
                }
            }
            return null;
        }

        public bool Remove(T value)
        {
            MyLinkedListNode<T> findNode = Find(value);
            if (findNode != null)
            {
                if (findNode != head)                       // 이전 노드가 있으면
                {
                    findNode.prev.next = findNode.next;     // 이전노드의 다음노드를 찾은노드 다음노드로
                }                                           // A - B - C => A - C
                else                                        // 이전 노드가 없으면
                {
                    head = findNode.next;                   // 삭제한 노드 다음 노드를 헤드로
                }                                           // A - B - C => B - C

                if (findNode != tail)                 
                {
                    findNode.next.prev = findNode.prev;
                }
                else
                {
                    tail = findNode.prev;
                }

                count--;
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            if (node != head)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
            else
            {
                head = node.next;
            }

            if (node != tail)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
            }

            count--;
        }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);
            if (node != head)
            {
                node.prev.next = newNode;
                newNode.prev = node.prev;
            }
            else
            {
                head = newNode;
            }

            newNode.next = node;
            node.prev = newNode;

            count++;
            return newNode;
        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);
            if (newNode != tail)
            {
                node.next.prev = newNode;
                newNode.next = node.next;
            }
            else
            {
                tail = newNode;
        
            }
            
            node.next = newNode;
            newNode.prev = node;
         
            count++;
            return newNode;
        }
    }
}
