using System;
using System.Linq;

namespace P4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            Array.Sort(input);

            int searchedIndex = -1;
            int searchedValue = k;
            while (searchedIndex < 0 && searchedValue >= input[0])
            {
                searchedIndex = Array.BinarySearch(input, searchedValue);
                searchedValue--;
            }

            if (searchedIndex > -1)
            {
                Console.WriteLine("The largest number <= {0} is {1}.", k, input[searchedIndex]);
            }
            else
            {
                Console.WriteLine("No number <= {0} was found.", k);
            }
        }
    }
}
