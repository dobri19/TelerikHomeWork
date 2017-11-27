using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace С08Irina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string searched = Console.ReadLine();
            string sentences = Console.ReadLine();
            string wordPattern = @"(\s" + searched + "\\s)";
            string sentencePattern = @"(\S.+?[.!?])(?=\s+|$)";
            Regex sentenceRG = new Regex(sentencePattern);
            Regex wordRG = new Regex(wordPattern);
            MatchCollection matched = sentenceRG.Matches(sentences);
            List<string> res = new List<string>();
            foreach (var item in matched)
            {
                if (wordRG.IsMatch(item.ToString()))
                {
                    res.Add(item.ToString());
                }
            }
            Console.WriteLine(string.Join(" ", res));
        }
    }
}
