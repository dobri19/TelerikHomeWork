using System;
using System.Numerics;

namespace Factorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            CalculateFac(number);
        }
        public static void CalculateFac(int number)
        {
            BigInteger factorial = 1;
            if (number < 0)
            {
                return;
            }
            else if (number == 0 || number == 1)
            {
                Console.WriteLine(factorial);
                return;
            }
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    factorial *= i;
                }
                Console.WriteLine(factorial);
                return;
            }
        }
    }
}
