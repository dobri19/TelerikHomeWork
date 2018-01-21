using System;

namespace _04Permitations04
{
    public class Permi
    {
        public static void Main(string[] args)
        {
            int n = 3;
            GetPerm(0, 1, n, new int[n], new bool[n]);
        }

        private static void GetPerm(int startIndex, int startValue, int endValue, int[] perm, bool[] isUsed)
        {
            if (startIndex == perm.Length)
            {
                Console.Write("({0}), ", string.Join(" ", perm));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                if (!isUsed[i - 1])
                {
                    perm[startIndex] = i;
                    isUsed[i - 1] = true;
                    GetPerm(startIndex + 1, startValue, endValue, perm, isUsed);
                    isUsed[i - 1] = false;
                }
            }
        }
    }
}
