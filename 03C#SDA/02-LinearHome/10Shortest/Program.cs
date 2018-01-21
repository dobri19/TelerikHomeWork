using System;
using System.Collections.Generic;

namespace _10Shortest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintShortestSequence(1, 16);
        }

        public static void PrintShortestSequence(int n, int m)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            while (sequence.Count > 0)
            {
                int current = sequence.Dequeue();

                Console.WriteLine(current);

                if (current == m)
                {
                    return;
                }

                current = current + 1;
                sequence.Enqueue(current);
                current = current + 2;
                sequence.Enqueue(current);
                current = current * 2;
                sequence.Enqueue(current);
            }
        }
    }
}
