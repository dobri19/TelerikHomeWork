using System;
using System.Text;

namespace S02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversed = ReversingString(text);
            Console.WriteLine(reversed);
        }

        public static string ReversingString(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            return sb.ToString();
        }
    }
}
