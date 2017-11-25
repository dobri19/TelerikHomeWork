using System;

namespace S06StringLength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length < 20)
            {
                input = input.PadRight(20, '*');
            }
            Console.WriteLine(input);
        }
    }
}
