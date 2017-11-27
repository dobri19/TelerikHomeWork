using System;
using System.Text.RegularExpressions;

namespace S05RegEx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            foreach (Match m in Regex.Matches(text, @"(<upcase>)([\w .]+)(</upcase>)"))
            {
                string replace = m.Groups[2].ToString();
                text = text.Replace(m.ToString(), replace.ToUpper());
            }
            Console.WriteLine(text);
            //string input = Console.ReadLine();
            //string pattern = @"(<upcase>)([\w .]+)(</upcase>)";
            //foreach (Match x in Regex.Matches(input, pattern))
            //{
            //    string y = x.Groups[2].ToString();
            //    input = input.Replace(x.ToString(), y.ToUpper());
            //}
            //Console.WriteLine(input);
        }
    }
}
