using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08LinkedListImplementation
{
    public class LinkedNode<T>
    {
        private LinkedNode<T> next;
        private LinkedNode<T> previous;
        private T value;
        //private NodesAreLinked<T> list;

        public LinkedNode(T value)
        {
            this.Value = value;
            this.Next = null;
            this.Previous = null;
        }

        //public NodesAreLinked<T> List()
        //{
        //    if (this.Next == null && this.previous == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return this.Next;
        //    }
        //}

        public LinkedNode<T> Next
        {
            get
            {
                return this.next;
            }
            internal set
            {
                this.next = value;
            }
        }
        public LinkedNode<T> Previous
        {
            get
            {
                return this.previous;
            }
            internal set
            {
                this.previous = value;
            }
        }
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
