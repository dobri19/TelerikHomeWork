using System;

namespace _03CombiWithoutDupli03
{
    public class CombiWithout
    {
        public static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            GetCombNoDuplicates(0, 1, n, new int[k]);
        }

        private static void GetCombNoDuplicates(int startIndex, int startValue, int endValue, int[] comb)
        {
            if (startIndex == comb.Length)
            {
                Console.Write("({0}), ", string.Join(" ", comb));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                comb[startIndex] = i;
                GetCombNoDuplicates(startIndex + 1, i + 1, endValue, comb);
            }
        }
    }
}
