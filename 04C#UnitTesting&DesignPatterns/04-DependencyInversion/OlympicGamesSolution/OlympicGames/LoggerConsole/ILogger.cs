using System;

namespace OlympicGames.LoggerConsole
{
    public interface ILogger
    {
        string Read();
        void Write(string text);
        void WriteFormat(string text, string ex);
    }
}
