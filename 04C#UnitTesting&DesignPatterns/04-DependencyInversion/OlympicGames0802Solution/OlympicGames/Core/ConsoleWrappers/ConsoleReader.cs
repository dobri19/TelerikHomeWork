using OlympicGames.Core.ConsoleWrappers;
using System;

namespace OlympicGames
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}