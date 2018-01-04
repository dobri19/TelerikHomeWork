using System;
using System.Timers;

namespace Problem07Timer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            TimerClass time = new TimerClass();
            DelegatePrintSeconds del = new DelegatePrintSeconds(time.Timer);
            del(1000);
        }

        //public static void OnEvent(object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("Merenge, merenge!");
        //    Console.WriteLine(e.SignalTime);
        //}
    }
}
