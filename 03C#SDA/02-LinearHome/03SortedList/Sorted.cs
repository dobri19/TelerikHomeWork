using System;
using System.Collections.Generic;

namespace _03SortedList
{
    public class Sorted
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter integer numbers:");
            List<int> sequence = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int number;
                if (int.TryParse(input, out number))
                {
                    sequence.Add(number);
                }
                else
                {
                    throw new ArgumentException("You must enter an integer number!");
                }

                input = Console.ReadLine();
            }

            sequence.Sort();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
