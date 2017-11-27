using System;
using System.Globalization;

namespace T1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);
            //TimeSpan oneDay = new TimeSpan(24, 0, 0);
            //date = date.Subtract(oneDay);
            date = date.Subtract(TimeSpan.FromDays(1));
            string formattedDate = date.ToString("d-MMM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(formattedDate);
        }
    }
}
