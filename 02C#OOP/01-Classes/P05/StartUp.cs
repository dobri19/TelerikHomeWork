using System;

namespace P05
{
    [AtttributeVersion("15.19")]
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var programVersion = typeof(StartUp).GetCustomAttributes(false);

            foreach (var item in programVersion)
            {
                var version = (AtttributeVersion)item;
                Console.WriteLine("Current Version: {0}", version.Version);
            }
        }
    }
}
