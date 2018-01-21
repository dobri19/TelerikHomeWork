using System;
using System.Collections.Generic;

namespace _07OccCount
{
    public class Occurance
    {
        public static void Main(string[] args)
        {
            var intList = new List<int> { 4, 2, 2, 5, 2, 1, 3, 512, 43, 512, 21, 22, 43, 2, 3, 1, 5, 2 };

            var intDictionary = new Dictionary<int, int>();

            for (int i = 0; i < intList.Count; i++)
            {
                var currentElement = intList[i];

                if (!intDictionary.ContainsKey(currentElement))
                {
                    intDictionary.Add(currentElement, 1);
                }
                else
                {
                    intDictionary[currentElement]++;
                }
            }

            foreach (var entry in intDictionary)
            {
                Console.WriteLine("{0} -> {1} occurences", entry.Key, entry.Value);
            }
        }
    }
}
