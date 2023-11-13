using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T> prev;
        public MyLinkedListNode<T> next;
        private T item;

        public MyLinkedListNode(T item)
        {
            this.prev = null;
            this.next = null;
            this.item = item;
        }

        public MyLinkedListNode(MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T item)
        {
            this.prev = prev;
            this.next = next;
            this.item = item;
        }

        public MyLinkedListNode<T> Prev { get { return prev; } }
        public MyLinkedListNode<T> Next { get { return prev; } }
        public T Item { get { return item; } set { item = value; } }
    }
}
