using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Queue
{
    // <만약 Queue를 LinkedList로 만든다면...>
    // internal class MyQueue<T>            
    // {
    //     private LinkedList<T> list;
       
    //     public MyQueue()
    //     {
    //         list = new LinkedList<T>();
    //     }
       
    //     public int Count { get { return list.Count; } }
       
    //     public void Enqueue(T item)
    //     {
    //         list.AddLast(item);
    //     }
       
    //     public T Dequeue()
    //     {
    //         // 만약 Queue를 List로 만든다면
    //         // list.RemoveAt(0) <-- 굉장히 비효율적인 작업이 생성됨
       
    //         T item = list.First();
    //         list.RemoveFirst();   
    //         return item;
    //     }
    // }                                     
    // 하지만 C#에서는 가비지 컬렉터가 DEQUEUE할 때마다 요소를 지워주어야 되기 때문에
    // LinkedList로 구현하지 않는다.

    // <Array로 관리>
    //   h                   t
    // | 0 | 1 | 2 | 3 | 4 |   |   |
    // EnQueue:              t->      추가 : t자리에 추가, t를 뒤로 한칸
    //   h                       t
    // | 0 | 1 | 2 | 3 | 4 | 5 |   |
    //   h->                :DeQueue  제거 : h자리를 제거, h를 뒤로 한칸
    //       h                   t
    // | 0 | 1 | 2 | 3 | 4 | 5 |   | 

    // <순환 구조> (원형/환형 배열)
    // 추가될 때 자리가 부족하면 앞의 자리를 빌린다.
    //       t       h
    // | 5 |   |   | 1 | 2 | 3 | 4 |

    // <비어있거나 꽉 찼거나>
    //  h/t
    // |   |   |   |   |   |   |   |
    //  h/t
    // | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
    // 헤드와 테일이 겹친다.
    //
    // 그래서 한칸의 여유를 갖고 더 큰 배열을 더 쓴다. 
    //   h                           t
    // | 0 | 1 | 3 | 4 | 5 | 6 | 7 | - |
    //   h                           t
    // | 0 | 1 | 3 | 4 | 5 | 6 | 7 | - |   |   |   |   |   |   |   |   |

    internal class MyQueue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;

        public MyQueue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public int Count
        {
            get
            {
                if (head <= tail)
                {
                    return tail - head;
                }
                else
                {
                    return tail + (array.Length - head);
                }
            }
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
            }

            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            
            T result = array[head];
            
            MoveNext(ref head);
            
            return array[head];
        }

        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];

            int i = 0;
            while (head != tail)
            {
                newArray[i] = array[head];
                i++;
                MoveNext(ref head);
            }

            //if (head < tail)
            //{
            //   Array.Copy(array, head, newArray, 0, tail);
            //}
            //else
            //{
            //    Array.Copy(array, head, newArray, 0, array.Length - head);
            //    Array.Copy(array, 0, newArray, array.Length - head, tail);
            //}

            head = 0;
            tail = Count;
            array = newArray;
        }

        private bool IsFull()
        {
            if (head == 0)
            {
                return tail == array.Length - 1;
            }
            else
            {
                return head == tail + 1;
            }
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        private void MoveNext(ref int index)
        {
            if (index == array.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }


    }

}
