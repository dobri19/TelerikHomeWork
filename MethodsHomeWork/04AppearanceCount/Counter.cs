using System;
using System.Linq;

namespace AppearanceCount
{
    public class Counter
    {
        public static void Main(string[] args)
        {
            int sizeArray = int.Parse(Console.ReadLine());
            string numbers = Console.ReadLine();
            int numberSearched = int.Parse(Console.ReadLine());
            Console.WriteLine(CountNumber(sizeArray, numbers, numberSearched));
        }
        public static int CountNumber(int size, string numbers, int number)
        {
            int counter = 0;
            int[] array = new int[size];
            array = numbers.Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
