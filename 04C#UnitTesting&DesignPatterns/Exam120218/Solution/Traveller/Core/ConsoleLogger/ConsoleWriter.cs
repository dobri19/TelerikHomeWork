using System;
using Traveller.Core.ConsoleLogger.Contracts;

namespace Traveller.Core.ConsoleLogger
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
