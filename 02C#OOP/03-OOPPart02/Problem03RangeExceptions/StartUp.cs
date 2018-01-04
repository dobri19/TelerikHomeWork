using System;

namespace Problem03RangeExceptions
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            EnterInt();
            EnterDateTime();
        }

        private static void EnterInt()
        {
            try
            {
                int start = 1;
                int end = 100;

                Console.WriteLine("Enter number outside 1 to 100!");
                int x = int.Parse(Console.ReadLine());

                if (x < start || x > end)
                {
                    throw new InvalidRangeException<int>(start, end, x);
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine($"{ire.Number} {ire.Message} [{ire.Start}, {ire.End}]");
            }
        }

        private static void EnterDateTime()
        {
            try
            {
                DateTime start = new DateTime(1980, 1, 1);
                DateTime end = new DateTime(2013, 12, 31);
                Console.WriteLine("Enter date from 1980 to 2014 //format 1980/01/01!//");
                DateTime x = DateTime.Parse(Console.ReadLine());

                if (x < start || x > end)
                {
                    throw new InvalidRangeException<DateTime>(start, end, x);
                }
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine($"{ire.Number.Year} {ire.Message} [{ ire.Start.Year}, {ire.End.Year}]");
            }
        }
    }
}
