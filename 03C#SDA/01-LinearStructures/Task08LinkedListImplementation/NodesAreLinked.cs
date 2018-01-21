using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08LinkedListImplementation
{
    public class NodesAreLinked<T> : IEnumerable<T>, IEnumerable
    {
        internal LinkedNode<T> head;
        internal int count;

        //private LinkedNode<T> firstNode;
        //private LinkedNode<T> lastNode;

        public NodesAreLinked()
        {
        }

        public LinkedNode<T> FirstNode
        {
            get
            {
                return this.head;
            }

            //set
            //{
            //    this.firstNode = value;
            //}
        }

        public LinkedNode<T> LastNode
        {
            get
            {
                if (this.head != null)
                {
                    return this.head.previous;
                }
                return null;
            }

            //set
            //{
            //    this.lastNode = value;
            //}
        }

        //public int Count()
        //{
        //    int count = 1;
        //    LinkedNode<T> current = this.FirstNode;
        //    if (current == null)
        //    {
        //        return 0;
        //    }
        //    while (current.Next != null)
        //    {
        //        current = current.Next;
        //        count += 1;
        //    }
        //    return count;
        //}

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public LinkedNode<T> AddFirst(T value)
        {
            LinkedNode<T> linkedListNode = new LinkedNode<T>(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(linkedListNode);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, linkedListNode);
                this.head = linkedListNode;
            }
            return linkedListNode;
        }

        public void AddFirst(LinkedNode<T> node)
        {
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, node);
                this.head = node;
            }
            node.list = this;
        }

        public LinkedNode<T> AddLast(T value)
        {
            LinkedNode<T> linkedListNode = new LinkedNode<T>(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(linkedListNode);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, linkedListNode);
            }
            return linkedListNode;
        }

        public void AddLast(LinkedNode<T> node)
        {
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, node);
            }
            node.list = this;
        }

        public void RemoveFirst()
        {
            //this.FirstNode = this.FirstNode.Next;
            //this.FirstNode.Previous = null;

            if (this.head == null)
            {
                throw new InvalidOperationException("LinkedListEmpty");
            }
            this.InternalRemoveNode(this.head);
        }

        public void RemoveLast()
        {
            //this.LastNode = this.LastNode.Previous;
            //this.LastNode.Next = null;

            if (this.head == null)
            {
                throw new InvalidOperationException("LinkedListEmpty");
            }
            this.InternalRemoveNode(this.head.previous);
        }

        public void Remove(LinkedNode<T> node)
        {
            //this.ValidateNode(node);
            this.InternalRemoveNode(node);

            //node.Previous.Next = node.Next;
            //node.Next.Previous = node.Previous;
            //node.Next = null;
            //node.Previous = null;
        }

        public bool Remove(T vvalue)
        {
            //bool found = false;
            //var current = this.FirstNode;
            //while (current != null)
            //{
            //    if (current.Value.Equals(vvalue))
            //    {
            //        Remove(current);
            //        found = true;
            //        break;
            //    }
            //    else
            //    {
            //        current = current.Next;
            //    }
            //}
            //return found;

            LinkedNode<T> linkedNode = this.Find(vvalue);
            if (linkedNode != null)
            {
                this.InternalRemoveNode(linkedNode);
                return true;
            }
            return false;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public LinkedNode<T> Find(T value)
        {
            LinkedNode<T> next = this.head;
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            if (next != null)
            {
                if (value != null)
                {
                    while (!@default.Equals(next.Value, value))
                    {
                        next = next.next;
                        if (next == this.head)
                        {
                            return null;
                        }
                    }
                    return next;
                }
                while (next.Value != null)
                {
                    next = next.next;
                    if (next == this.head)
                    {
                        return null;
                    }
                }
                return next;
            }
            //IL_5A:
            return null;
        }

        public void Clear()
        {
            LinkedNode<T> next = this.head;
            while (next != null)
            {
                LinkedNode<T> linkedListNode = next;
                next = next.Next;
            }
            this.head = null;
            this.count = 0;
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

        private void InternalInsertNodeToEmptyList(LinkedNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.previous = newNode;
            this.head = newNode;
            this.count++;
        }

        private void InternalInsertNodeBefore(LinkedNode<T> node, LinkedNode<T> newNode)
        {
            newNode.next = node;
            newNode.previous = node.previous;
            node.previous.next = newNode;
            node.previous = newNode;
            this.count++;
        }

        internal void InternalRemoveNode(LinkedNode<T> node)
        {
            if (node.next == node)
            {
                this.head = null;
            }
            else
            {
                node.next.previous = node.previous;
                node.previous.next = node.next;
                if (this.head == node)
                {
                    this.head = node.next;
                }
            }
            this.count--;
        }
    }
}
