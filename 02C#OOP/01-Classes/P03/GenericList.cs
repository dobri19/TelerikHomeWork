using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03
{
    public class GenericList<T> where T : IComparable
    {
        // fields
        private const int InitialCapacity = 1;
        private int count;
        private int capacity;

        //constructor
        public GenericList(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.ListArray = new T[this.Capacity];
        }

        //propeerties
        private T[] ListArray { get; set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("The capacity cannot be less than one!!!");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The count cannot be less than zero!!!");
                }
                else
                {
                    this.count = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return this.ListArray[index];
            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.ListArray[index] = value;

            }
        }

        //methods
        public void Add(T element)
        {
            this.Count++;

            this.ListArray[this.Count - 1] = element;

            DoubleListArray();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index + 1; i < this.Count; i++)
            {
                this.ListArray[i - 1] = this.ListArray[i];
            }
            this.Count--;
            ReduceListArray();
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of space!");
            }

            this.Count++;
            this.DoubleListArray();

            for (int i = this.Count; i > index; i--)
            {
                this.ListArray[i] = this.ListArray[i-1];
            }
            this.ListArray[index] = element;
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.ListArray = new T[InitialCapacity];
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.ListArray, element);
        }

        public T Max()
        {
            T max = default(T);

            if (this.Count > 0)
            {
                max = this.ListArray[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.ListArray[i].CompareTo(max) > 0)
                    {
                        max = this.ListArray[i];
                    }
                }
            }

            return max;
        }

        public T Min()
        {
            T min = default(T);

            if (this.Count > 0)
            {
                min = this.ListArray[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.ListArray[i].CompareTo(min) < 0)
                    {
                        min = this.ListArray[i];
                    }
                }
            }

            return min;
        }

        public bool Contains(T element)
        {
            return this.ListArray.Contains(element);
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Empty list!";
            }
            else
            {
                string[] temp = new string[this.Count];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.ListArray[i].ToString();
                }
                return String.Join(", ", temp);
            }
        }

        private void DoubleListArray()
        {
            if (this.Count > (this.Capacity * 3) / 4)
            {
                this.Capacity *= 2;
                T[] array = (T[])ListArray.Clone();
                Array.Resize(ref array, this.Capacity);
                this.ListArray = (T[])array.Clone();
            }
        }

        private void ReduceListArray()
        {
            if (this.Count <= this.Capacity / 3)
            {
                this.Capacity /= 3;
            }
        }
    }
}
