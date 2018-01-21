using System;

namespace _00ReverseStringR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(Recursion(input));
        }

        private static string Recursion(string input)
        {
            string result = "";

            if (input == string.Empty)
            {
                return input;
            }

            string lastSymbol = input.Substring(input.Length - 1);
            result = lastSymbol + Recursion(input.Remove(input.Length - 1, 1));

            return result;
        }
    }
}
