using System;
using System.Diagnostics;
using Traveller.Core.Contracts;

namespace Traveller.Core.Decorator
{
    public class TimingEngine : EngineDecorator
    {
        public TimingEngine(IEngine engine)
            : base(engine)
        {
        }

        public override void Start()
        {
            Console.WriteLine("The Engine is starting...");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            this.engine.Start();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("The Engine worked for {0} milliseconds.", ts);
        }
    }
}
