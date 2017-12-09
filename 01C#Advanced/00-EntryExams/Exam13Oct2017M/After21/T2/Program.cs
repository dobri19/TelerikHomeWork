using System;
using System.Collections.Generic;

namespace T2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> primeNumbers = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            foreach (int item in primeNumbers)
            {
                for (int i = 1; i <= item; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }
        }

        public static bool IsPrime(int n)
        {
            if (n <= 3)
            {
                return true;
            }

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
