using System;
using System.Linq;

namespace Neighbors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string numbers = Console.ReadLine();
            int[] arr = numbers.Split(' ').Select(x => int.Parse(x)).ToArray();
            int count = CountNeighbors(arr);
            Console.WriteLine(count);
        }
        public static int CountNeighbors(int[] array)
        {
            int counter = 0;
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1] && array[i - 1] < array[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
