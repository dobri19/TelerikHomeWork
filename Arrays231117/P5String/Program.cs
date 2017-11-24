using System;
using System.Linq;

namespace P5String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input;
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sorted = SortByLength(input);
            Console.WriteLine("Input: {0}", string.Join(" ", input));
            Console.WriteLine("Sorted: {0}", string.Join(" ", sorted));
        }

        public static string[] SortByLength(string[] input)
        {
            string[] sorted = input.OrderBy(x => x.Length).ToArray();
            return sorted;
        }
    }
}
