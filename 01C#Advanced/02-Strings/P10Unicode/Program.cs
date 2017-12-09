using System;
using System.Text;

namespace P10Unicode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charsArray = input.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < charsArray.Length; i++)
            {
                builder.Append("\\u" + ((int)charsArray[i]).ToString("X4"));
            }
            Console.WriteLine(builder);
        }
    }
}
