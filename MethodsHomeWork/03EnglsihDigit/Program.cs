using System;

namespace EnglsihDigit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(EnglishPatient(a));
        }

        private static string EnglishPatient(int a)
        {
            string englishWord;
            int number = a % 10;

            switch (number)
            {
                case 0:
                    englishWord = "zero";
                    break;
                case 1:
                    englishWord = "one";
                    break;
                case 2:
                    englishWord = "two";
                    break;
                case 3:
                    englishWord = "three";
                    break;
                case 4:
                    englishWord = "four";
                    break;
                case 5:
                    englishWord = "five";
                    break;
                case 6:
                    englishWord = "six";
                    break;
                case 7:
                    englishWord = "seven";
                    break;
                case 8:
                    englishWord = "eight";
                    break;
                case 9:
                    englishWord = "nine";
                    break;
                default:
                    englishWord = "not a digit.";
                    break;
            }

            return englishWord;
        }
    }
}
