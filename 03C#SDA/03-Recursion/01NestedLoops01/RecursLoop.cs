using System;

namespace _01NestedLoops01
{
    public class RecursLoop
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            RecursiveNesting(0, 1, n, new int[n]);
        }

        public static void RecursiveNesting(int startIndex, int startValue, int endValue, int[] loops)
        {
            if (startIndex == loops.Length)
            {
                Console.WriteLine(string.Join(" ", loops));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                loops[startIndex] = i;
                RecursiveNesting(startIndex + 1, startValue, endValue, loops);
            }
        }
    }
}
