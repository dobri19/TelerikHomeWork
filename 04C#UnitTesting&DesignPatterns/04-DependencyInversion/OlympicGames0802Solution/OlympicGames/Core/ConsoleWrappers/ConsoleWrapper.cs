using OlympicGames.Core.ConsoleWrappers;

namespace OlympicGames
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public ConsoleWrapper(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string ReadWithWrapper()
        {
            return this.reader.ReadLine();
        }

        public void WriteWithWrapper(string msg)
        {
            this.writer.WriteLine(msg);
        }
    }
}