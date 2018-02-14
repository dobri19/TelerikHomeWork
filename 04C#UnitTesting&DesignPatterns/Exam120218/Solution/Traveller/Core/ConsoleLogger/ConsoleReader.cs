using System;
using Traveller.Core.ConsoleLogger.Contracts;

namespace Traveller.Core.ConsoleLogger
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
