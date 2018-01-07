using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07StackImplementation
{
    public class MineStack<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;
        private const int SizeDelta = 4;

        private T[] items;
        private int size;

        public MineStack()
        {
            this.items = new T[InitialSize];
            this.size = 0;
        }

        public int Capacity()
        {
            return this.items.Length;
        }

        public int Count()
        {
            return this.size;
        }

        public void Push(T item)
        {
            if (item == null)
            {
                return;
            }

            if (size == this.Capacity())
            {
                this.items = this.ResizeArray();
            }

            this.items[size] = item;

            this.size++;
        }

        public T Peek()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.items[size - 1];
        }

        public T Pop()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            this.size--;

            var item = this.items[this.size];

            this.items[this.size] = default(T);

            return item;
        }

        private T[] ResizeArray()
        {
            var newArr = new T[this.Capacity() + SizeDelta];

            for (int i = 0; i < this.Capacity(); i++)
            {
                newArr[i] = this.items[i];
            }

            return newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var i = 0;

            while (i < this.size)
            {
                yield return this.items[i];

                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
