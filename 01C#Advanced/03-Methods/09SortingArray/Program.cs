using System;
using System.Linq;

namespace SortingArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sorted = SortArray(array);
            PrintArray(sorted);
        }
        public static int[] SortArray(int[] array)
        {
            Array.Sort(array);
            return array;
        }
        public static void PrintArray(int[] sorted)
        {
            for (int i = 0; i < sorted.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write(sorted[0]);
                }
                else
                {
                    Console.Write(" ");
                    Console.Write(sorted[i]);
                }
            }
        }
    }
}
