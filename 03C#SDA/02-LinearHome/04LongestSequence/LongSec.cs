using System;
using System.Collections.Generic;
using System.Linq;

namespace _04LongestSequence
{
    public class LongSec
    {
        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>()
            {
                1, 2, 2, 2, 4, 3, 3, 3, 5, 5
            };

            //List<int> longest = GetLongestEqualSubsequence(sequence);
            //List<int> longest = GetLongestEqualSubsequenceWithLinq(sequence);

            Console.WriteLine("Initial sequence: ");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine("Longest subsequence of equals: ");
            List<int> longest = GetLongestEqual(sequence);
            //Console.WriteLine(string.Join(", ", longest));
        }

        public static List<int> GetLongestEqual(List<int> numbers)
        {
            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> longestEqualSubsequence = new List<int>();
            int[] repeatNum = new int[2];
            int currentCount = 1;
            int biggestCount = 1;
            repeatNum[0] = numbers[0];
            repeatNum[1] = currentCount;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentCount++;
                    if (currentCount > biggestCount)
                    {
                        biggestCount = currentCount;
                        repeatNum[1] = biggestCount;
                        repeatNum[0] = numbers[i];
                    }
                }
                else
                {
                    currentCount = 1;
                }
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat(repeatNum[0] + " ", repeatNum[1])));
            return longestEqualSubsequence;
        }

        public static List<int> GetLongestEqualSubsequenceWithLinq(List<int> numbers)
        {
            List<int> longestEqualSubsequence = new List<int>();

            longestEqualSubsequence = numbers.Select((n, i) => new { Value = n, Index = i })
                .OrderBy(s => s.Value)
                .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
                .GroupBy(s => new { s.Value, s.Diff })
                .OrderByDescending(g => g.Count())
                .First()
                .Select(f => f.Value)
                .ToList();

            return longestEqualSubsequence;
        }
    }
}
