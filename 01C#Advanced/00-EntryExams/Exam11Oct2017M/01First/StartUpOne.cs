using System;

namespace First
{
    public class StartUpOne
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long sum = long.MaxValue;

            while (sum >= 10)
            {
                sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        sum = sum + (input[i] - '0');
                    }
                }

                input = sum.ToString();
            }

            Console.WriteLine(input);
        }
    }
}
