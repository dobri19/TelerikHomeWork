using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06QueueImplementation
{
    public class QueueMine<T> : IEnumerable<T>
    {
        private List<T> collection;

        public int Capacity
        {
            get { return this.collection.Capacity; }
            private set {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("CAPACITY MUST BE POSITIVE NUMBER!!!");
                }
                this.collection.Capacity = value; }
        }

        public QueueMine()
        {
            this.collection = new List<T>();
        }

        public QueueMine(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public QueueMine(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
        }

        public int Count
        {
            get
            {
                return this.collection.Count;
            }
        }

        public void Clear()
        {
            this.collection.Clear();
        }

        public bool Contains(T item)
        {
            return this.collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex, j = 0; i < array.Length; i++, j++)
            {
                array[i] = this.collection[j];
            }
        }

        public T Dequeue()
        {
            var first = this.collection.First();
            this.collection.Remove(first);

            return first;
        }

        public void Enqueue(T item)
        {
            this.collection.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T Peek()
        {
            return this.collection.First();
        }

        public T[] ToArray()
        {
            var array = new T[this.collection.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.collection[i];
            }

            return array;
        }

        public void TrimExcess()
        {
            if (this.collection.Count * 10 / 9 <= this.collection.Capacity )
            {
                this.collection.Capacity = this.Count;
            }
        }
    }
}
