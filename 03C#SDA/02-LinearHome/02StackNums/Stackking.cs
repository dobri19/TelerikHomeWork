using System;
using System.Collections.Generic;

namespace _02StackNums
{
    public class Stackking
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of integers:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {number} integer numbers:");
            string input = Console.ReadLine();

            Stack<int> stackOfNumbers = new Stack<int>();

            while (!input.Equals(string.Empty))
            {
                int num;
                if (int.TryParse(input, out num))
                {
                    stackOfNumbers.Push(num);
                }
                else
                {
                    throw new ArgumentException("Must enter integer numbers!");
                }

                input = Console.ReadLine();
            }

            while (stackOfNumbers.Count > 0)
            {
                Console.WriteLine(stackOfNumbers.Pop());
            }
        }
    }
}
