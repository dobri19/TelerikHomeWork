using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Problem07Timer
{
    public delegate void DelegatePrintSeconds(int interval);

    public class TimerClass
    {
        public void Timer(int interval)
        {
            while (true)
            {
                Thread.Sleep(interval);
                DateTime date = DateTime.Now;
                int currentSeconds = date.Second;
                Console.WriteLine(currentSeconds);
            }

            //public static void Timer(int interval, Action<object, ElapsedEventArgs> method)
            //{
            //    Timer timer = new Timer();
            //    timer.Elapsed += new ElapsedEventHandler(method);
            //    timer.Interval = interval;
            //    timer.Enabled = true;
            //    Console.WriteLine("Press \'z\' to quit.");
            //    while (true) ;
            //}
        }
    }
}
