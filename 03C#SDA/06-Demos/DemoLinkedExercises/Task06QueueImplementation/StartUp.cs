using System;
using System.Collections.Generic;

namespace Task06QueueImplementation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var queue1 = new QueueMine<int>();
            queue1.Enqueue(1);
            queue1.Enqueue(2);
            queue1.Enqueue(3);
            queue1.Enqueue(4);

            var queue2 = new QueueMine<string>(10);
            queue2.Enqueue("hello");
            queue2.Enqueue("new");
            queue2.Enqueue("future");

            var queue3 = new QueueMine<int>(queue1);

            Console.WriteLine("Queue1 count: {0}", queue1.Count);
            Console.Write("Queue1 : ");
            while (queue1.Count > 0)
            {
                Console.Write(queue1.Dequeue() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Queue1 capacity: {0}", queue1.Capacity);
            
            Console.WriteLine();

            Console.WriteLine("Queue2 count: {0}", queue2.Count);
            Console.Write("Queue2 : ");
            while (queue2.Count > 0)
            {
                Console.Write(queue2.Dequeue() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Queue2 capacity: {0}", queue2.Capacity);
            
            Console.WriteLine();

            Console.WriteLine("Queue3 peek: {0}", queue3.Peek());
            Console.WriteLine("Does Queue3 contain 1? {0}", queue3.Contains(1));
            queue3.Dequeue();
            Console.WriteLine("Does Queue3 contain 1? {0}", queue3.Contains(1));
            Console.WriteLine();

            queue3.Enqueue(5);
            queue3.Enqueue(6);
            queue3.Enqueue(7);
            queue3.Enqueue(8);
            queue3.Enqueue(9);
            queue3.Enqueue(10);
            queue3.Enqueue(11);

            Console.WriteLine("Queue3 capacity: {0}", queue3.Capacity);
            Console.WriteLine("Queue3 count: {0}", queue3.Count);
            queue3.TrimExcess();
            Console.WriteLine("Queue3 capacity: {0}", queue3.Capacity);
            Console.WriteLine("Queue3 count: {0}", queue3.Count);

            //queue3.Clear();
        }
    }
}
