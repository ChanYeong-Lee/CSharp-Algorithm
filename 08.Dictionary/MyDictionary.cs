using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Dictionary
{
    public class MyDictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public State state;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;
        private int addCount;
        private int deleteCount;

        public MyDictionary()
        {
            table = new Entry[DefaultCapacity];
            addCount = 0;
            deleteCount = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (TryGetValue(key, out value))
                    return value;
                else
                    throw new KeyNotFoundException();
            }
            set
            {
                TryInsert(key, value, InsertionBehavior.OverrideExist);
            }
        }

        public void Add(TKey key, TValue value)
        {
            TryInsert(key, value, InsertionBehavior.ThrowOnExisting);
        }

        public bool TryAdd(TKey key, TValue value)
        {
            return TryInsert(key, value, InsertionBehavior.None);
        }

        public void Clear()
        {
            table = new Entry[DefaultCapacity];
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out var value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                value = table[index].value;
                return true;
            }
        }

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                return false;
            }
            else
            {
                table[index].state = Entry.State.Deleted;
                deleteCount++;
                return true;
            }
        }

        private enum InsertionBehavior { None, OverrideExist, ThrowOnExisting }
        private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            int collisionCount = 0;
            while (true)
            {
                if (table[index].state == Entry.State.None)
                {
                    break;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))
                    {
                        switch (behavior)
                        {
                            case InsertionBehavior.OverrideExist:
                                table[index].key = key;
                                table[index].value = value;
                                return true;
                            case InsertionBehavior.ThrowOnExisting:
                                throw new ArgumentException();
                            case InsertionBehavior.None:
                            default:
                                return false;
                        }
                    }
                }

                index = (index + 1) % table.Length;

                if (++collisionCount >= table.Length)
                    throw new InvalidOperationException();
            }

            table[index].state = Entry.State.Using;
            table[index].key = key;
            table[index].value = value;
            addCount++;

            if (addCount + deleteCount > table.Length * 0.7f)
                ReHashing();

            return true;
        }

        private int FindIndex(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            int collisionCount = 0;
            while (true)
            {
                if (table[index].state == Entry.State.None)
                {
                    return -1;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))
                    {
                        return index;
                    }
                }

                index = (index + 1) % table.Length;

                if (++collisionCount >= table.Length)
                    throw new InvalidOperationException();
            }
        }

        private void ReHashing()
        {
            int newSize = (addCount - deleteCount) * 5 + DefaultCapacity;
            Entry[] newTable = new Entry[newSize];
            addCount = 0;
            deleteCount = 0;

            foreach (Entry entry in table)
            {
                TKey key = entry.key;
                TValue value = entry.value;

                int index = Math.Abs(key.GetHashCode() % newTable.Length);
                while (true)
                {
                    if (newTable[index].state == Entry.State.None)
                    {
                        break;
                    }

                    index = (index + 1) % table.Length;
                }

                newTable[index].state = Entry.State.Using;
                newTable[index].key = key;
                newTable[index].value = value;
                addCount++;
            }

            table = newTable;
        }
    }
}

