using System;
using System.Diagnostics;
using System.Threading;

namespace Problem08
{
    public class Program
    {
        public static event EventHandler<ConsoleKey> HandleEnter;

        public static void CaptureKeyPressed(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                HandleEnter(null, ConsoleKey.Enter);
            }
        }

        public static void HandleKeyPress(object sender, ConsoleKey key)
        {
            Console.Clear();
            StopWatch.Seconds = 0;
        }

        public static void TickerCount(object sender, ConsoleKey key)
        {
            Console.WriteLine("Starting Stopwatch...");
            Console.WriteLine("\nPress [ENTER] to reset the Stopwatch.\n");

            var action = StopWatch.Action;

            while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Thread.Sleep(1000);
                action(++StopWatch.Seconds);
            }
        }

        public static void Main()
        {
            Console.WriteLine("Press [ENTER] to start the Stopwatch!");

            HandleEnter = HandleKeyPress;

            HandleEnter += TickerCount;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    CaptureKeyPressed(Console.ReadKey().Key);
                }
            }
        }
    }
}
