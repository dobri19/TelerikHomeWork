using System;
using System.Collections.Generic;

namespace _06RemoveOdd
{
    public class Oddetst
    {
        public static void Main(string[] args)
        {
            List<int> sequenceList = new List<int>()
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            };

            List<int> evenOccurances = RemoveOddOccurances(sequenceList);
            Console.WriteLine(string.Join(", ", evenOccurances));
        }

        public static List<int> RemoveOddOccurances(List<int> numbers)
        {
            Dictionary<int, int> occurancesCount = new Dictionary<int, int>();

            foreach (var item in numbers)
            {
                if (occurancesCount.ContainsKey(item))
                {
                    occurancesCount[item]++;
                }
                else
                {
                    occurancesCount.Add(item, 1);
                }
            }

            List<int> evenOccurances = new List<int>();

            foreach (var item in numbers)
            {
                if (occurancesCount[item] % 2 == 0)
                {
                    evenOccurances.Add(item);
                }
            }

            return evenOccurances;
        }
    }
}
