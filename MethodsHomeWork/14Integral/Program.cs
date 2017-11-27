using System;
using System.Linq;

namespace _14Integral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            AllIntegerCalc(input);
        }
        static void AllIntegerCalc(int[] array)
        {
            long product = 1;
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Max());
            Console.WriteLine("{0:f2}", array.Average());
            Console.WriteLine(array.Sum());
            foreach (long item in array)
            {
                product *= item;
            }
            Console.WriteLine(product);
        }
    }
}
