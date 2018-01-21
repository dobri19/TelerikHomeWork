using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08LinkedListImplementation
{
    public class LinkedNode<T>
    {
        internal LinkedNode<T> next;
        internal LinkedNode<T> previous;
        internal T value;
        internal NodesAreLinked<T> list;

        public LinkedNode(T value)
        {
            this.Value = value;
            //this.Next = null;
            //this.Previous = null;
        }

        internal LinkedNode(NodesAreLinked<T> list, T value)
        {
            this.list = list;
            this.Value = value;
        }

        public NodesAreLinked<T> List
        {
            get
            {
                return this.list;
            }
        }

        public LinkedNode<T> Next
        {
            get
            {
                //return this.next;
                if (this.next != null && this.next != this.list.head)
                {
                    return this.next;
                }
                return null;
            }
        }

        public LinkedNode<T> Previous
        {
            get
            {
                if (this.previous != null && this != this.list.head)
                {
                    return this.previous;
                }
                return null;
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
