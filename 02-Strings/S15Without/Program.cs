using System;
using System.Text;

namespace S15Without
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string htmlDoc = Console.ReadLine();

            StringBuilder textWOTags = new StringBuilder();
            StringBuilder urlAdress = new StringBuilder();
            StringBuilder siteName = new StringBuilder();

            for (int index = 0, start = 0, end = 0; ;)
            {
                string tag = string.Empty;
                if (htmlDoc.IndexOf("<a", index) != -1)
                {
                    start = htmlDoc.IndexOf("<a", index);
                    end = htmlDoc.IndexOf("/a>", index);
                    tag = htmlDoc.Substring(start, end - start);

                    textWOTags.Append(htmlDoc.Substring(index, start - index));
                    urlAdress.Append(tag.Substring(tag.IndexOf("\"") + 1, tag.LastIndexOf("\"") - tag.IndexOf("\"") - 1));
                    siteName.Append(tag.Substring(tag.IndexOf(">") + 1, tag.LastIndexOf("<") - tag.IndexOf(">") - 1));

                    textWOTags.Append("[");
                    textWOTags.Append(siteName);
                    textWOTags.Append("]");

                    textWOTags.Append("(");
                    textWOTags.Append(urlAdress);
                    textWOTags.Append(")");

                    index = end + 3;
                    urlAdress.Remove(0, urlAdress.Length);
                    siteName.Remove(0, siteName.Length);
                }
                else
                {
                    textWOTags.Append(htmlDoc.Substring(index, htmlDoc.Length - index));
                    break;
                }
            }
            Console.WriteLine(textWOTags.ToString());
        }
    }
}
