using System;

namespace ReverseNumber
{
    public class Reverse
    {
        public static void Main(string[] args)
        {
            string decimalNumber = Console.ReadLine();
            string res = ReverseNum(decimalNumber);
            Console.WriteLine(res);
        }
        public static string ReverseNum(string number)
        {
            char[] arr = number.ToString().ToCharArray();
            Array.Reverse(arr);
            string result = new string(arr);
            return result;
        }
    }
}
