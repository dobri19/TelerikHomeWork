using System;
using System.Globalization;

namespace S19Canada
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTimeFormatInfo formatInfo = (new CultureInfo("ca-CA")).DateTimeFormat;
            //DateTime date1 = new DateTime(1, 12, 1);
            DateTime date2 = new DateTime(2000, 10, 5);
            Console.WriteLine(date2.ToString("yyyy,MM,dd"));
            Console.WriteLine(date2);
        }
    }
}
