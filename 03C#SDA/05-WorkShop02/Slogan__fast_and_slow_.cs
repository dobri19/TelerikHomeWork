using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slogan
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveFast();
            //SolveSlow();
        }

        #region Solve Fast
        private static void SolveFast()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var suggestedWords = Console.ReadLine().Split().ToList();
                string slogan = Console.ReadLine();

                List<string> usedWords = new List<string>();
                HashSet<string> impossibleWords = new HashSet<string>();
                if (GenerateSlogansFast(suggestedWords, slogan, usedWords, impossibleWords))
                {
                    usedWords.Reverse();
                    resultBuilder.AppendLine(string.Join(" ", usedWords));
                }
                else
                {
                    resultBuilder.AppendLine("NOT VALID");
                }
            }

            Console.WriteLine(resultBuilder);
        }

        private static bool GenerateSlogansFast(IEnumerable<string> suggestedWords, string slogan,
            List<string> usedWords, HashSet<string> impossibleSlogans)
        {
            if (slogan == string.Empty)
            {
                return true;
            }

            if (impossibleSlogans.Contains(slogan))
            {
                return false;
            }

            foreach (string word in suggestedWords)
            {
                if (slogan.StartsWith(word))
                {
                    string restOfSlogan = slogan.Substring(word.Length);
                    if (GenerateSlogansFast(suggestedWords, restOfSlogan, usedWords, impossibleSlogans))
                    {
                        usedWords.Add(word);
                        return true;
                    }
                }
            }

            impossibleSlogans.Add(slogan);
            return false;
        }
        #endregion

        #region Solve Slow
        // Solve like Messages in Bottle
        private static void SolveSlow()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var suggestedWords = Console.ReadLine().Split().ToList();
                string slogan = Console.ReadLine();

                List<string> resultSlogans = new List<string>();
                StringBuilder sloganBuilder = new StringBuilder();
                GenerateSlogansSlow(suggestedWords, slogan, sloganBuilder, resultSlogans);
                if (resultSlogans.Count > 0)
                {
                    resultBuilder.AppendLine(resultSlogans[0]);
                }
                else
                {
                    resultBuilder.AppendLine("NOT VALID");
                }
            }

            Console.WriteLine(resultBuilder);
        }

        private static void GenerateSlogansSlow(List<string> suggestedWords, string slogan,
             StringBuilder sloganBuilder, List<string> originalMessages)
        {
            if (slogan == string.Empty)
            {
                originalMessages.Add(sloganBuilder.ToString());
                return;
            }

            foreach (string word in suggestedWords)
            {
                if (slogan.StartsWith(word))
                {
                    string wordToAdd = $"{word} ";
                    sloganBuilder.Append(wordToAdd);

                    string restOfSlogan = slogan.Substring(word.Length);
                    GenerateSlogansSlow(suggestedWords, restOfSlogan, sloganBuilder, originalMessages);

                    sloganBuilder.Length -= wordToAdd.Length;
                }
            }

            return;
        }
        #endregion
    }
}
