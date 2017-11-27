using System;

namespace S03Brackets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool correctBrackets = true;
            int counter = 0;
            for (int index = 0; index < input.Length; index++)
            {
                char ch = input[index];
                if (ch == '(')
                {
                    counter++;
                }
                else if (ch == ')')
                {
                    counter--;
                    if (counter < 0)
                    {
                        correctBrackets = false;
                        Console.WriteLine("Incorrect");
                        return;
                    }
                }
            }
            if (counter != 0)
            {
                correctBrackets = false;
                Console.WriteLine("Incorrect");
            }
            if (correctBrackets)
            {
                Console.WriteLine("Correct");
            }
        }
    }
}
