using System;

namespace S04Substring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string str = Console.ReadLine();
            pattern = pattern.ToLower();
            str = str.ToLower();
            int counter = 0;
            int index = 0;
            while (true)
            {
                int found = str.IndexOf(pattern, index);
                if (found < 0)
                {
                    break;
                }
                counter++;
                index = found + 1;
            }
            Console.WriteLine(counter);
        }
    }
}
