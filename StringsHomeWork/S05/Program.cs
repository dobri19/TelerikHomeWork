using System;

namespace S05
{
    public class Program
    {
        private static string openTag = "<upcase>";
        private static string closeTag = "</upcase>";

        static void Main()
        {
            string inputText = Console.ReadLine();
            string replacedText = ReplaceTags(inputText);
            Console.WriteLine(replacedText);
        }
        private static string ReplaceTags(string text)
        {
            string[] textToTransform = text.Split(new[] { openTag, closeTag }, StringSplitOptions.None);
            for (int i = 1; i < textToTransform.Length; i += 2)
            {
                textToTransform[i] = textToTransform[i].ToUpper();
            }
            return string.Concat(textToTransform);
        }
    }
}
