using System;

namespace VFirst
{
    public class Crooked
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            PrintCrookedDigit(number);
        }

        private static void PrintCrookedDigit(string number)
        {
            long sumOfDigits = long.MaxValue;
            byte crookedDigit = 0;

            while (sumOfDigits > 9)
            {
                sumOfDigits = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (char.IsDigit(number[i]))
                    {
                        sumOfDigits += (int)char.GetNumericValue(number[i]);
                    }
                }

                number = sumOfDigits.ToString();
            }

            crookedDigit = (byte)sumOfDigits;
            Console.WriteLine(crookedDigit);
        }
    }
}
