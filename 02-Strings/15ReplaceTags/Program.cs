using System;
using System.Text.RegularExpressions;

namespace _15ReplaceTags
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patern = @"<a href=""(.*)"">(.*)";
            string replace = @"[URL=…](…/URL)";
            var arr = text.Split(new[] { "</a>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Regex.Replace(arr[i], patern, m => "[" + m.Groups[2].Value + "](" + m.Groups[1].Value + ")");
            }
            text = string.Join("", arr);
            Console.WriteLine(text);
        }
    }
}
