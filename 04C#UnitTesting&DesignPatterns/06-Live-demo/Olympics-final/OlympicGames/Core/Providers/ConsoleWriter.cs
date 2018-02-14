using OlympicGames.Core.Contracts;
using System;

namespace OlympicGames.Core.Providers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public ConsoleWriter()
        {

        }
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}