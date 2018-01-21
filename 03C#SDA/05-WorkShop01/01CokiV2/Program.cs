using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CokiV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            var allNodes = new Dictionary<int, Node>();
            var list = new List<int>();
            var sb = new StringBuilder();

            Node head = null;
            Node previous = null;

            for (int i = 0; i < n; i++)
            {
                var currentNode = new Node(i, previous);
                previous = currentNode;

                if (head == null)
                {
                    head = currentNode;
                }

                allNodes.Add(i, currentNode);
                list.Add(i);
            }

            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var a = tokens[0];
                var b = tokens[1];

                if (list.IndexOf(a) > list.IndexOf(b))
                {
                    var currentNode = allNodes[a];

                    while (currentNode.Next != null && currentNode.Next.Value < b)
                    {
                        currentNode = currentNode.Next;
                    }
                    MoveBAfterA(allNodes[b], ref currentNode, ref head);

                    list.Remove(b);
                    list.Insert(list.IndexOf(currentNode.Value) + 1, b);
                }
            }

            var node = head;

            while (node != null)
            {
                sb.AppendLine(node.Value.ToString());
                node = node.Next;
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void MoveBAfterA(Node nodeToBeMoved, ref Node secondNode, ref Node head)
        {
            var prev = nodeToBeMoved.Previous;
            var next = nodeToBeMoved.Next;

            if (prev == null)
            {
                next.Previous = null;
                head = next;
            }
            else
            {
                next.Previous = prev;
                prev.Next = next;
            }

            if (secondNode.Next == null)
            {
                nodeToBeMoved.Next = null;
            }
            else
            {
                secondNode.Next.Previous = nodeToBeMoved;
                nodeToBeMoved.Next = secondNode.Next;
            }
            secondNode.Next = nodeToBeMoved;
            nodeToBeMoved.Previous = secondNode;
        }
    }

    public class Node
    {
        public Node(int value, Node previous)
        {
            this.Value = value;
            this.Previous = previous;

            if (previous != null)
            {
                this.Previous.Next = this;
            }
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}
