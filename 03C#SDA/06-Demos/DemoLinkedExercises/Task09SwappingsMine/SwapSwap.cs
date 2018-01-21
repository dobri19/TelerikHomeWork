using System;
using System.Linq;

namespace Task09SwappingsMine
{
    public class SwapSwap
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stivs = Console.ReadLine().Split().Select(int.Parse).ToList();

            Node[] links = new Node[n + 1];
            links[0] = new Node(null, 0);

            for (int i = 1; i < n + 1; i++)
            {
                links[i] = new Node(links[i - 1], i);
            }

            var start = links[1];
            var end = links[n];

            foreach (var xxx in stivs)
            {
                var middle = links[xxx];
                var previous = middle.Left;
                var next = middle.Right;

                Node.Detach(middle);
                Node.Attach(middle, start);
                Node.Attach(end, middle);

                start = next ?? middle;
                end = previous ?? middle;
            }

            var numbers = new int[n];
            for (int i = 0; i < n; ++i)
            {
                numbers[i] = start.Value;
                start = start.Right;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node(Node previous, int value)
        {
            this.Value = value;

            if (previous == null)
            {
                this.Left = previous;
                this.Right = null;
            }
            else
            {
                this.Left = previous;
                this.Right = null;
                previous.Right = this;
            }
        }

        public static void Detach(Node node)
        {
            if (node.Left != null)
            {
                node.Left.Right = null;
            }

            if (node.Right != null)
            {
                node.Right.Left = null;
            }

            node.Left = null;
            node.Right = null;
        }

        public static void Attach(Node nodePrevious, Node nodeNext)
        {
            if (nodePrevious == nodeNext)
            {
                return;
            }

            nodePrevious.Right = nodeNext;
            nodeNext.Left = nodePrevious;
        }
    }
}
