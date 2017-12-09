using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class Enter
    {
        public static void Main()
        {
            List<int> result = new List<int>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    result.Add(int.Parse(Console.ReadLine()));
                }
                if (result.Count != 10 || result[0] <= 1 || result[9] >= 100)
                {
                    throw new Exception();
                }
                for (int i = 1; i < 10; i++)
                {
                    if (result[i] <= result[i - 1])
                    {
                        throw new Exception();
                    }
                }
                Console.WriteLine("1 < " + string.Join(" < ", result) + " < 100");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
        //public static double ReadNumber(int start, int end)
        //{
        //    double result;
        //    result = Math.Sqrt(n);
        //    return result;
        //}
    }
}
