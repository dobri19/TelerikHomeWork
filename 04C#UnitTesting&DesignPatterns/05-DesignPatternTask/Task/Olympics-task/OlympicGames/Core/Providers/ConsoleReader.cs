using OlympicGames.Core.Contracts;
using System;

namespace OlympicGames.Core.Providers
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}