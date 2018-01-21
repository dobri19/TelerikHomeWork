using System;
using System.Collections.Generic;

namespace Task08LinkedListImplementation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //LinkedList<int> asd = new LinkedList<int>();
            LinkedListNode<int> nnn = new LinkedListNode<int>(5);
            //asd.AddFirst(nnn);
            //nnn.Next = new LinkedListNode<string>("catty");

            var list = new NodesAreLinked<string>();
            var mouseLink = new LinkedNode<string>("mouse");
            //Console.WriteLine(mouseLink.List.ToString());

            list.AddFirst(mouseLink);
            //Console.WriteLine(mouseLink.List().ToString());

            var catLink = new LinkedNode<string>("catty");
            list.AddLast(catLink);
            var dogLink = new LinkedNode<string>("doggy");
            list.AddLast(dogLink);

            list.AddLast("bauuuuu");

            Console.WriteLine(catLink.Value);
            Console.WriteLine(catLink.Next);
            Console.WriteLine(catLink.Previous);
            Console.WriteLine(catLink.ToString());
            Console.WriteLine();

            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine();

            int count = list.Count();
            Console.WriteLine("Elements count: {0}", count);
            Console.WriteLine();

            list.RemoveFirst();
            list.RemoveLast();

            Console.WriteLine("All elements after removing the first and last one:");

            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine("List contains catty? {0}", list.Contains("catty")); ;
            Console.WriteLine();

            Console.WriteLine(list.FirstNode);
            Console.WriteLine(list.LastNode);

            //Console.WriteLine(catLink.List().ToString());
        }
    }
}
