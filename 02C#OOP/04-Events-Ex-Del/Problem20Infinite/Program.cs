using System;
using System.Linq;

namespace Problem20Infinite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Sum(m => 1 / (decimal)Math.Pow(2, m - 1)));
            Console.WriteLine(Sum(m => 1m / Enumerable.Range(1, m).Aggregate((a, b) => a * b)));
            Console.WriteLine(Sum(m => -1 / (decimal)Math.Pow(-2, m - 1)));

            // sum of 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
            // start = 1; step = 2
            double firstSum = Sum02.CalculateSum(1, 2, false, 0, (x, y) => Sum02.NextMember(x, y));
            Console.WriteLine(firstSum);

            // sum of 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
            double secondSum = Sum02.CalculateSum(1, 2, false, 1, (x, y) => Sum02.NextMember(x, y));
            Console.WriteLine(secondSum);

            // sum of 1 + 1/2 - 1/4 + 1/8 - 1/16 + … 
            double thirdSum = Sum02.CalculateSum(1, 2, true, 0, (x, y) => Sum02.NextMember(x, y));
            Console.WriteLine(thirdSum);
        }

        private static decimal Sum(Func<int, decimal> f)
        {
            decimal sum = 1;
            for (int i = 2; Math.Abs(f(i)) > 0.001m; i++) sum += f(i);
            return sum;
        }
    }
}
