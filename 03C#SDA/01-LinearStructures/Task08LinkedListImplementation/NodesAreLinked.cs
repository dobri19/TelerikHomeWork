using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08LinkedListImplementation
{
    public class NodesAreLinked<T> : IEnumerable<T>
    {
        private LinkedNode<T> firstNode;
        private LinkedNode<T> lastNode;

        public NodesAreLinked()
        {
        }

        public LinkedNode<T> FirstNode
        {
            get
            {
                return this.firstNode;
            }

            set
            {
                this.firstNode = value;
            }
        }
        public LinkedNode<T> LastNode
        {
            get
            {
                return this.lastNode;
            }

            set
            {
                this.lastNode = value;
            }
        }
        public int Count()
        {
            int count = 1;
            LinkedNode<T> current = this.FirstNode;
            if (current == null)
            {
                return 0;
            }
            while (current.Next != null)
            {
                current = current.Next;
                count += 1;
            }
            return count;
        }

        public void AddFirst(T value)
        {
            if (this.FirstNode == null)
            {
                this.FirstNode = new LinkedNode<T>(value);
            }
            else if (this.Count() == 0)
            {
                var newNode = new LinkedNode<T>(value);
                this.FirstNode = newNode;
                this.LastNode = newNode;
            }
            else
            {
                var newNode = new LinkedNode<T>(value);
                newNode.Next = this.FirstNode;
                this.FirstNode.Previous = newNode;
                this.FirstNode = newNode;
            }
        }

        public void AddFirst(LinkedNode<T> node)
        {
            //if (this.FirstNode == null)
            //{
            //    this.FirstNode = node;
            //}
            //else 
            if (this.Count() == 0)
            {
                var newNode = node;
                this.FirstNode = newNode;
                this.LastNode = newNode;
            }
            else
            {
                var newNode = node;
                newNode.Next = this.FirstNode;
                this.FirstNode.Previous = newNode;
                this.FirstNode = newNode;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstNode == null)
            {
                this.FirstNode = new LinkedNode<T>(value);
            }
            else
            {
                var newNode = new LinkedNode<T>(value);
                newNode.Previous = this.LastNode;
                this.LastNode.Next = newNode;
                this.LastNode = newNode;
            }
        }

        public void AddLast(LinkedNode<T> node)
        {
            if (this.FirstNode == null)
            {
                this.FirstNode = node;
            }
            else
            {
                var newNode = node;
                newNode.Previous = this.LastNode;
                this.LastNode.Next = newNode;
                this.LastNode = newNode;
            }
        }

        public void RemoveFirst()
        {
            this.FirstNode = this.FirstNode.Next;
            this.FirstNode.Previous = null;
        }

        public void RemoveLast()
        {
            this.LastNode = this.LastNode.Previous;
            this.LastNode.Next = null;
        }

        public void Remove(LinkedNode<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Next = null;
            node.Previous = null;
        }

        public bool Remove(T vvalue)
        {
            bool found = false;
            var current = this.FirstNode;
            while (current != null)
            {
                if (current.Value.Equals(vvalue))
                {
                    Remove(current);
                    found = true;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return found;
        }

        public bool Contains(T vvalue)
        {
            bool found = false;
            var current = this.FirstNode;
            while (current != null)
            {
                if (current.Value.Equals(vvalue))
                {
                    found = true;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return found;
        }

        public void Clear()
        {
            this.FirstNode = null;
            this.LastNode = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.FirstNode;

            while (currentItem != null)
            {
                yield return currentItem.Value;

                currentItem = currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
