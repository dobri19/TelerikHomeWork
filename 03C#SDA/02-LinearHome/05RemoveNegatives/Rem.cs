using System;
using System.Collections.Generic;

namespace _05RemoveNegatives
{
    public class Rem
    {
        public static void Main(string[] args)
        {
            List<int> sequenceList = new List<int>()
            {
                1, -2, -3, 4, -7, -3, 2
            };

            Console.WriteLine("Sequence before removing negatives:");
            Console.WriteLine(string.Join(", ", sequenceList));

            List<int> positiveSequence = RemoveNegativesList(sequenceList);

            Console.WriteLine("Sequence after removing negatives:");
            Console.WriteLine(string.Join(", ", positiveSequence));
        }

        public static List<int> RemoveNegativesList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            return numbers;
        }
    }
}
