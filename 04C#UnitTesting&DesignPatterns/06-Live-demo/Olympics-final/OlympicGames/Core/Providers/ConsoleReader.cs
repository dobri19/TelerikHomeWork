using OlympicGames.Core.Contracts;
using System;

namespace OlympicGames.Core.Providers
{
    public class ConsoleReader : IConsoleReader
    {
        public ConsoleReader()
        {

        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}