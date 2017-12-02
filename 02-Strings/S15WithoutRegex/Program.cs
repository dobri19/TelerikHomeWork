using System;
using System.Text;

namespace S15WithoutRegex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new string[] { "<a href=" }, StringSplitOptions.None);
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var link = "";
                if (text[i][0] != '"')
                {
                    sb.Append(text[i]);
                }
                else
                {
                    link = text[i].Substring(1);
                    var index = link.IndexOf('"');
                    link = link.Substring(0, index);
                    var indexTitleStart = text[i].IndexOf("\">");
                    var indexTitleEnd = text[i].IndexOf("</a>");
                    var title = text[i].Substring(indexTitleStart + 2, indexTitleEnd - 2 - indexTitleStart);
                    var restOfText = text[i].Substring(indexTitleEnd + 3).TrimStart('>');
                    sb.Append("[" + title + "]");
                    sb.Append("(" + link + ")");
                    sb.Append(restOfText);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
