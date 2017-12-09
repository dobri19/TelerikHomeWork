using System;
using System.Text;

namespace S23Series
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            builder.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != builder[builder.Length - 1])
                {
                    builder.Append(input[i]);
                }
            }
            string result = builder.ToString();
            Console.WriteLine(result);
        }
    }
}
