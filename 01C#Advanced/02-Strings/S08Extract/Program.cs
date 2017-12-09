using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace S08Extract
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            //List<string> sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> sentences = text.Split('.').ToList();
            char[] separators = text.Where(c => !char.IsLetter(c)).Distinct().ToArray();

            foreach (string sentence in sentences)
            {
                //List<string> words = sentence.Split(new char[] { ' ', ',', '-', ';', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (words.Contains(word))
                {
                    builder.Append(sentence.Trim() + ". ");
                }
            }
            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
