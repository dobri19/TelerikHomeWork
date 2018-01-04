using System;
using System.Collections.Generic;

namespace Program17Longest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> collection = new List<string>()
            {
                "Hello",
                "How Are You",
                "Barbi"
            };
            string maxString = collection.MaxLenghtOfString();
            Console.WriteLine(maxString);
        }
    }
}
