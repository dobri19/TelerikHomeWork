using System;
using System.Collections.Generic;

namespace CountingWords
{
    public class Counting
    {
        public static void Main(string[] args)
        {
            string text = "Welcome to our C# course. In this " +
            "course you will learn how to write simple " +
            "programs in C# and how to use data structures";

            Console.WriteLine("Dictionary<TKey,TValue>");
            Console.WriteLine("-----------------------");
            IDictionary<string, int> wordsCount = new Dictionary<string, int>();
            CountWords(text, wordsCount);

            Console.WriteLine();
            Console.WriteLine("SortedDictionary<TKey,TValue>");
            Console.WriteLine("-----------------------------");
            IDictionary<string, int> sortedWordsCount = new SortedDictionary<string, int>();
            CountWords(text, sortedWordsCount);
        }

        private static void CountWords(string text, IDictionary<string, int> wordsCount)
        {
            string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                }
                else
                {
                    wordsCount.Add(word, 1);
                    //wordsCount[word] = 1;
                }
            }

            foreach (var pair in wordsCount)
            {
                Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
            }
        }
    }
}
