using System;
using System.Collections.Generic;
using System.Linq;

namespace Task05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var links = new Link[n + 1];
            for (int i = 1; i <= n; i++)
            {
                links[i] = new Link(links[i - 1], i);
            }

            var leftEnd = links[1];
            var rightEnd = links[n];

            foreach (int x in arr)
            {
                var middle = links[x];
                var newRight = middle.Left;
                var newLeft = middle.Right;

                Link.DetachLink(middle);
                Link.AttachLink(rightEnd, middle);
                Link.AttachLink(middle, leftEnd);

                leftEnd = newLeft ?? middle;
                rightEnd = newRight ?? middle;
            }

            var numbers = new int[n];
            for (int i = 0; i < n; ++i)
            {
                numbers[i] = leftEnd.Value;
                leftEnd = leftEnd.Right;
            }

            Console.WriteLine(string.Join(" ", numbers));

            //do
            //{
            //    Console.WriteLine(leftEnd.Value);
            //    leftEnd = leftEnd.Right;
            //}
            //while (leftEnd != null);
        }
    }

    public class Link
    {
        public int Value { get; set; }
        public Link Left { get; set; }
        public Link Right { get; set; }

        public Link(Link last, int value)
        {
            this.Value = value;

            this.Left = last;
            this.Right = null;

            if (last != null)
            {
                last.Right = this;
            }
        }

        public static void DetachLink(Link link)
        {
            if (link.Left != null)
            {
                link.Left.Right = null;
            }

            if (link.Right != null)
            {
                link.Right.Left = null;
            }

            link.Left = null;
            link.Right = null;
        }

        public static void AttachLink(Link left, Link right)
        {
            if (left == right)
            {
                return;
            }

            left.Right = right;
            right.Left = left;
        }
    }
}
