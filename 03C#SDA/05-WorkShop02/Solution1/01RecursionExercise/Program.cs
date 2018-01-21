using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01RecursionExercise
{
    public class Program
    {
        //static string slogan;
        static List<string> foundWords = new List<string>();
        static List<string> words;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string slogan = Console.ReadLine();

                HashSet<string> impossible = new HashSet<string>();
                if (CheckSlogan(slogan, impossible))
                {
                    foundWords.Reverse();
                    result.AppendLine(string.Join(" ", foundWords));
                    foundWords.Clear();
                }
                else
                {
                    result.AppendLine("NOT VALID");
                }
            }

            Console.Write(result);
        }

        private static bool CheckSlogan(string slogan, HashSet<string> impossible)
        {
            //string xxx = slogan.Substring(sloganIndex);

            if (slogan == string.Empty)
            {
                return true;
            }

            if (impossible.Contains(slogan))
            {
                return false;
            }

            foreach (var word in words)
            {
                if (slogan.StartsWith(word))
                {
                    if (CheckSlogan(slogan.Substring(word.Length), impossible))
                    {
                        foundWords.Add(word);
                        return true;
                    }
                }
            }

            impossible.Add(slogan);
            return false;
        }
    }
}
