using System;
using System.Collections.Generic;
using System.Linq;

namespace ListNumbers
{
    public class Listing
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter positive integer numbers:");
            string input = Console.ReadLine();

            List<int> listOfNumbers = new List<int>();

            while (!input.Equals(string.Empty))
            {
                int number;
                if (int.TryParse(input, out number) && number > 0)
                {
                    listOfNumbers.Add(number);
                }
                else
                {
                    throw new ArgumentException("Must enter positive integer numbers!");
                }

                input = Console.ReadLine();
            }

            int sum = listOfNumbers.Sum();
            double average = listOfNumbers.Average();

            Console.WriteLine($"The sum of the list numbers is : {sum}");
            Console.WriteLine($"The average of the list numbers is : {average}");
        }
    }
}
