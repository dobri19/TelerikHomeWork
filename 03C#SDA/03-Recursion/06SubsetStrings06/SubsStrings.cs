using System;

namespace _06SubsetStrings06
{
    public class SubsStrings
    {
        public static void Main(string[] args)
        {
            string[] set = { "test", "rock", "fun" };
            int k = 2;
            GetCombNoDuplicates(0, 0, set, new string[k]);
        }

        private static void GetCombNoDuplicates(int startIndex, int startIndexSet, string[] set, string[] comb)
        {
            if (startIndex == comb.Length)
            {
                Console.Write("({0}), ", string.Join(" ", comb));
                return;
            }

            for (int i = startIndexSet; i < set.Length; i++)
            {
                comb[startIndex] = set[i];
                GetCombNoDuplicates(startIndex + 1, i + 1, set, comb);
            }
        }
    }
}
