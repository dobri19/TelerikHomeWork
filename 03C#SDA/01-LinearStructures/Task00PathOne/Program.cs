using System;
using System.Collections.Generic;

namespace Task00PathOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());

            int steps = Divide(n);

            Console.WriteLine(steps);
        }

        public static int Divide(uint n, int depth = 0)
        {
            if (n == 1)
            {
                return depth;
            }

            if (n % 2 == 0)
            {
                return Divide(n / 2, depth + 1);
            }

            int d1 = Divide(n + 1, depth + 1);
            int d2 = Divide(n - 1, depth + 1);

            return Math.Min(d1, d2);
        }
    }
}
