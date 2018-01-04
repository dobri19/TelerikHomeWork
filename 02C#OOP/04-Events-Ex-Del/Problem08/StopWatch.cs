using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem08
{
    //public delegate void Ticker();

    public static class StopWatch
    {
        public static readonly Action<int> Action = new Action<int>((x) => Console.WriteLine(x));
        //public static readonly Action Action = new Action(() => Console.WriteLine(++Seconds));

        public static int Seconds { get; set; }
    }
}
