using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionsV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberOfActions = input1[0];
            int numberOfOrders = input1[1];

            var dict = new Dictionary<int, List<int>>(); // key => Node.Value  ; value => Node.AdjacencyList
            for (int i = 0; i < numberOfActions; i++)
            {
                dict.Add(i, new List<int>());
            }

            for (int i = 0; i < numberOfOrders; i++)
            {
                int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int first = input2[0];
                int second = input2[1];

                dict[second].Add(first);
            }

            // Sorting algorithm
            var result = new Queue<int>();

            for (int i = 0; i < numberOfActions; i++)
            {
                List<int> potentialStarts = new List<int>();

                foreach (var item in dict)
                {
                    if (!item.Value.Any())
                    {
                        potentialStarts.Add(item.Key);
                    }
                }
                int first = potentialStarts.Min();

                result.Enqueue(first);
                dict.Remove(first);

                foreach (var item in dict)
                {
                    if (item.Value.Contains(first))
                    {
                        item.Value.Remove(first);
                    }
                }
            }

            // Printing:
            for (int i = 0; i < numberOfActions; i++)
            {
                Console.WriteLine(result.Dequeue());
            }
        }
    }
}
