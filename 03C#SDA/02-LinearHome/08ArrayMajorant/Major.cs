using System;
using System.Collections.Generic;

namespace _08ArrayMajorant
{
    public class Major
    {
        public static void Main(string[] args)
        {
            var intList = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            FindMajorant(intList);
        }

        public static void FindMajorant(IList<int> intList)
        {
            var dominanceReq = intList.Count / 2 + 1;

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
                if (entry.Value >= dominanceReq)
                {
                    Console.WriteLine("The majorant of the array is {0}.", entry.Key);
                    return;
                }
            }

            Console.WriteLine("No majorant is present in the array.");
        }
    }
}
