using System;
using System.Text.RegularExpressions;

namespace S15VReplace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            //string parsedHTML = Regex.Replace(text, "(<a href=\")(.*?)(\">)(.*?)(</a>)", "[$4]($2)");
            //Console.WriteLine(parsedHTML);

            var input = Console.ReadLine();

            while (true)
            {
                if (!input.Contains(@"<a href="))
                {
                    Console.WriteLine(input);
                    break;
                }
                var tagStartIndex = input.IndexOf(@"<a href=");
                var tagEndIndex = input.IndexOf(@"</a>") + 4;
                var tag = input.Substring(tagStartIndex, tagEndIndex - tagStartIndex);

                var urlStartIndex = input.IndexOf(@"<a href=") + 9;
                var urlEndIndex = input.IndexOf(@""">");
                var url = input.Substring(urlStartIndex, urlEndIndex - urlStartIndex);

                var textStartIndex = urlEndIndex + 2;
                var textEndIndex = tagEndIndex - 4;
                var text = input.Substring(textStartIndex, textEndIndex - textStartIndex);
                input = input.Replace(tag, string.Format("[{0}]({1})", text, url));
            }
        }
    }
}
