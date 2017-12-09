using System;

namespace SquareRoot
{
    public class Square
    {
        public static void Main(string[] args)
        {
            try
            {
                double n = double.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new Exception();
                }
                double root = CalculateRoot(n);
                PrintRoot(root);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
        public static double CalculateRoot(double n)
        {
            double result;
            result = Math.Sqrt(n);
            return result;
        }
        public static void PrintRoot(double n)
        {
            Console.WriteLine("{0:0.000}", n);
        }
    }
}
