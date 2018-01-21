using System;
using System.Collections.Generic;

namespace _09QueueSeq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintSequence(2);
        }

        public static void PrintSequence(int n)
        {
            const int CountToPrint = 50;
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            for (int i = 0; i < CountToPrint; i++)
            {
                int current = sequence.Dequeue();

                Console.WriteLine(current);

                sequence.Enqueue(current + 1);
                sequence.Enqueue(2 * current + 1);
                sequence.Enqueue(current + 2);
            }
        }
    }
}
