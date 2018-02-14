using OlympicGames.Core.ConsoleWrappers;
using System;

namespace OlympicGames
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}