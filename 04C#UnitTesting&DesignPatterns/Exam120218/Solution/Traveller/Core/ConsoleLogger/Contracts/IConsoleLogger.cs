namespace Traveller.Core.ConsoleLogger.Contracts
{
    public interface IConsoleLogger
    {
        void WriteWithLogger(string msg);

        void WriteLineWithLogger(string msg);

        string ReadLineWithLogger();
    }
}
