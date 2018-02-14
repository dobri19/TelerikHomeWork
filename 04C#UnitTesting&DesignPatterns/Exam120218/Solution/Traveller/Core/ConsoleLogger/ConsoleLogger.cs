using System;
using System.Collections.Generic;
using System.Text;
using Traveller.Core.ConsoleLogger.Contracts;

namespace Traveller.Core.ConsoleLogger
{
    public class ConsoleLogger : IConsoleLogger
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public ConsoleLogger(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string ReadLineWithLogger()
        {
            return this.reader.ReadLine();
        }

        public void WriteWithLogger(string msg)
        {
            this.writer.Write(msg);
        }

        public void WriteLineWithLogger(string msg)
        {
            this.writer.WriteLine(msg);
        }
    }
}
