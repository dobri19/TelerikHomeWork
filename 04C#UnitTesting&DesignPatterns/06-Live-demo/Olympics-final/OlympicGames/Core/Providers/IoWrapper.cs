using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers
{
    public class IoWrapper : IIoWrapper
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public IoWrapper(IConsoleWriter writer, IConsoleReader reader)
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