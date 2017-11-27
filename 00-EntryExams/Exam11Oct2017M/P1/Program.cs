using System;

namespace P1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int bigSum = int.MaxValue;

            while (bigSum > 9)
            {
                int sum = 0;

                for (int i = 0; i < n.Length; i++)
                {
                    if (char.IsDigit(n[i]))
                    {
                        sum += n[i] - '0';
                    }
                }

                bigSum = sum;
                n = bigSum.ToString();
            }

            Console.WriteLine(bigSum);
        }
    }
}
