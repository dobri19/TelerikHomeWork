using System;
using System.Collections.Generic;
using System.Linq;

namespace Pair
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string size = Console.ReadLine();
            int[] sizeArray = size.Split(' ').Select(int.Parse).ToArray();
            int[] firstArray = InputArrayAsString(sizeArray[0]);
            int[] secondArray = InputArrayAsString(sizeArray[1]);
            List<int> sumOfTwoArrays = SumOfTwoArrays(firstArray, secondArray);
            PrintSumOfTheArrays(sumOfTwoArrays);
        }
        public static int[] InputArrayAsString(int size)
        {
            string arrayAsString = Console.ReadLine();
            int[] intArray = new int[size];
            intArray = arrayAsString.Split(' ').Select(int.Parse).ToArray();
            return intArray;
        }
        public static List<int> SumOfTwoArrays(int[] firstArray, int[] secondArray)
        {
            List<int> sumOfTwoArrays = new List<int>();
            int sum = 0;
            int keepInMind = 0;
            KeyValuePair<int[], int[]> pair = WhoIsTheSmallestArray(firstArray, secondArray);
            int[] smallestArray = pair.Value;
            int[] bigestArray = pair.Key;
            for (int i = 0; i < bigestArray.Length; i++)
            {
                if (i < smallestArray.Length)
                {
                    if (smallestArray[i] + bigestArray[i] + keepInMind > 9)
                    {
                        sum = (smallestArray[i] + bigestArray[i] + keepInMind) % 10;
                        sumOfTwoArrays.Add(sum);
                        keepInMind = 1;
                    }
                    else
                    {
                        sum = smallestArray[i] + bigestArray[i] + keepInMind;
                        sumOfTwoArrays.Add(sum);
                        keepInMind = 0;
                    }
                }
                else
                {
                    sum = bigestArray[i] + keepInMind + 0;
                    if (sum > 9)
                    {
                        sum %= 10;
                        keepInMind = 1;
                    }
                    else
                    {
                        keepInMind = 0;
                    }
                    sumOfTwoArrays.Add(sum);
                }
            }
            return sumOfTwoArrays;
        }
        public static KeyValuePair<int[], int[]> WhoIsTheSmallestArray(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length > secondArray.Length)
            {
                return new KeyValuePair<int[], int[]>(firstArray, secondArray);
            }
            else if (firstArray.Length < secondArray.Length)
            {
                return new KeyValuePair<int[], int[]>(secondArray, firstArray);
            }
            else
            {
                return new KeyValuePair<int[], int[]>(secondArray, firstArray);
            }
        }
        public static void PrintSumOfTheArrays(List<int> sumOfTwoArrays)
        {

            for (int i = 0; i < sumOfTwoArrays.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(sumOfTwoArrays[0]);
                }
                else
                {
                    Console.Write(" ");
                    Console.Write(sumOfTwoArrays[i]);
                }
            }
        }
    }
}
