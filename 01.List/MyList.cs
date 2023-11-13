using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List
{
    internal class MyList<T>
    {
        // List도 크기를 줄였다 늘렸다 할 수는 없다.
        // 동적 할당되어 힙영역에 저장되는 당시에 크기가 결정되고 변하지 않는다.
        // 그래서 List는 처음부터 크게 만들고 쓰는 부분만 쓰고
        // 데이터가 추가되면 안 쓰던 부분에 저장하는 방식으로 크기를 늘리는 것처럼 작동한다.
        // 그래서 Capacity를 미리 설정해주면 데이터 관리에 용이함.
        // 또한 List 크기가 커지면 List를 분할해서 사용하는 것도 생각해볼만 함 (deque)

        private const int DefaultCapacity = 4;

        private T[] items;
        private int size;
        public int Capacity { get { return items.Length; }  }
        public int Count { get { return size; } }

        public MyList()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public T this[int index]        // 인덱서
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size >= items.Length)
            {
                Grow();
            }
            items[size] = item;
            size++;
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newItems[i] = items[i];
            }
            // Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
            // 기존 데이터는 가비지 컬렉터가 삭제해버림. Cpp의 경우 delete 사용
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;       // TODO : 이거 구현해야 함 <작업목록>
        }

        public void RemoveAt(int index) // 몇번째 꺼 지워줘
        {
            if (index < 0 || index >= size)
            {
                //Console.WriteLine("범위를 벗어나는 삭제는 불가능합니다.");
                //return;
                throw new IndexOutOfRangeException();
            }
            size--;
            Array.Copy(items, index + 1, items, index, size - index);  // 지운 뒤에 한칸씩 앞으로 당긴다.
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException();

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, size, match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > size - count)
                throw new ArgumentOutOfRangeException();
            if (match == null)
                throw new ArgumentNullException();

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(items[i])) return i;
            }
            return -1;
        }
    }
}
