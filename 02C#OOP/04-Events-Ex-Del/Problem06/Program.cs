using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 456, 564, 14, 21, 44566, 76, 242, 29, 4, 16, 4 };
            Console.WriteLine("1: Using Ex: ");
            List<int> sortedNumbers = numbers.Where(x => (x % 7 == 0) && (x % 3 == 0)).ToList();
            foreach (var item in sortedNumbers)
            {
                Console.WriteLine(item);
            }

            var divisibleNumbers =
                from number in numbers
                where number % 7 == 0 && number % 3 == 0
                select number;
            Console.WriteLine("2: Using LINQ query: ");
            Console.WriteLine(string.Join(Environment.NewLine, divisibleNumbers));
        }
    }
}
