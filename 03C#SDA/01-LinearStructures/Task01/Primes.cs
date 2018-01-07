using System;
using System.Collections.Generic;

namespace Task01
{
    public class Primes
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 200; i <= 300; i++)
            {
                numbers.Add(i);
            }

            numbers = FindPrimes(numbers);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }

        public static List<int> FindPrimes(List<int> numbers)
        {
            List<int> primeNumbers = new List<int>();
            foreach (var item in numbers)
            {
                if (IsPrime(item))
                {
                    primeNumbers.Add(item);
                }
            }
            return primeNumbers;
        }

        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
