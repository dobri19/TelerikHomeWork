using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberArray
{
    public class NumArray
    {
        public static void Main(string[] args)
        {
            string size = Console.ReadLine();
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string firstNumber = string.Join("", firstArray);
            int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string secondNumber = string.Join("", secondArray);
            string summedArrays = SumNumbers(firstNumber, secondNumber);
            char[] sum = summedArrays.ToCharArray();
            string result = string.Join(" ", sum);
            Console.WriteLine(result);
        }
        public static string SumNumbers(string firstNumber, string secondNumber)
        {
            char[] first = ConvertNumber(firstNumber);
            char[] second = ConvertNumber(secondNumber);
            return SumArrays(first, second);
        }
        public static char[] ConvertNumber(string number)
        {
            char[] digits = number.ToCharArray();
            return digits;
        }
        public static string SumArrays(char[] first, char[] second)
        {
            int a = first.Length;
            int b = second.Length;
            int biggest;
            if (a > b)
            {
                biggest = a;
            }
            else
            {
                biggest = b;
            }
            char[] result;
            if (a < b)
            {
                char[] nnn = new char[biggest];
                for (int i = 0; i < first.Length; i++)
                {
                    nnn[i] = first[i];
                }
                result = new char[biggest];
            }
            else
            {
                int[] nnn = new int[biggest];
                for (int i = 0; i < second.Length; i++)
                {
                    nnn[i] = second[i];
                }
                result = new char[biggest];
            }
            int sum = 0;
            int inner = 0;
            for (int i = 0; i < biggest; i++)
            {
                sum = biggest[i] + shortest[i] + inner;
                inner = sum / 10;
                sum = sum % 10;
                result[i] = (char)(sum + '0');
            }
            return new string(result).TrimStart('0');
        }
    }
}
