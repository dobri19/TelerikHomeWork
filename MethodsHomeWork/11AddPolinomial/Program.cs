using System;
using System.Linq;

namespace _11AddPolinomial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sumPoly = Sum(first, second, size);
            Print(sumPoly);
        }
        public static int[] Sum(int[] first, int[] second, int size)
        {
            int[] sumPolynomials = new int[size];
            for (int i = 0; i < size; i++)
            {
                sumPolynomials[i] = first[i] + second[i];
            }
            return sumPolynomials;
        }
        public static void Print(int[] sumPolynomials)
        {
            for (int i = 0; i < sumPolynomials.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write(sumPolynomials[0]);
                }
                else
                {
                    Console.Write(" ");
                    Console.Write(sumPolynomials[i]);
                }
            }
        }
    }
}

