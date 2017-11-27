using System;
using System.Linq;

namespace GetLargest
{
    public class LargestNumber
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxNumber = GetMax(array[2], GetMax(array[0], array[1]));
            Console.WriteLine(maxNumber);
        }
        public static int GetMax(int first, int second)
        {
            int biggest;
            if (first > second)
            {
                biggest = first;
            }
            else
            {
                biggest = second;
            }
            return biggest;
        }
    }
}
