using System;
using System.Collections.Generic;

namespace Task01BinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 10, 10, 10, 10, 10, 55, 367, 767, 4564 };
            Console.WriteLine(BinarySearch(list, 4564));
        }

        public static int BinarySearch(List<int> list, int n)
        {
            return RecursiveBinary(0, list.Count - 1, list, n);
        }

        public static int RecursiveBinary(int start, int end, List<int> list, int n)
        {
            if (n < list[start] || n > list[end])
            {
                return -1;
            }

            if (start == end)
            {
                if (list[start] == n)
                {
                    return n;
                }

                return -1;
            }

            if (list == null || list.Count == 0)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (list[mid] == n)
            {
                return n;
            }

            if (n < list[mid])
            {
                return RecursiveBinary(start, mid, list, n);
            }

            return RecursiveBinary(mid + 1, end, list, n);
        }
    }
}
