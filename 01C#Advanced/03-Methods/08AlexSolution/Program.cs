using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arraysLengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var array1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var array2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            SumOfTwoArrays(arraysLengths, array1, array2);
        }
        public static void SumOfTwoArrays(int[] arraysLengths, List<int> array1, List<int> array2)
        {
            var sizeArray1 = arraysLengths[0];
            var sizeArray2 = arraysLengths[1];
            var result = new List<int>();
            var remainder = 0;
            if (sizeArray1 > sizeArray2)
            {
                for (int i = 0; i < sizeArray1 - sizeArray2; i++)
                {
                    array2.Add(0);
                }
            }
            else if (sizeArray2 > sizeArray1)
            {
                for (int i = 0; i < sizeArray2 - sizeArray1; i++)
                {
                    array1.Add(0);
                }
            }
            for (int i = 0; i < array1.Count(); i++)
            {
                var currentSum = array1[i] + array2[i] + remainder;

                if (currentSum < 10)
                {
                    result.Add(currentSum);
                    remainder = 0;
                }
                else
                {
                    result.Add(currentSum % 10);
                    remainder = 1;
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

