using System;

namespace _05Variations05
{
    public class Varri
    {
        public static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            string[] set = { "hi", "a", "b" };
            GetVariations(0, new string[k], set);
        }

        private static void GetVariations(int startIndex, string[] vars, string[] set)
        {
            if (startIndex == vars.Length)
            {
                Console.Write("({0}), ", string.Join(" ", vars));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                vars[startIndex] = set[i];
                GetVariations(startIndex + 1, vars, set);
            }
        }
    }
}
