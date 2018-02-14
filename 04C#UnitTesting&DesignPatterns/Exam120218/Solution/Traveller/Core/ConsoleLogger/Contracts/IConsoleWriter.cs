namespace Traveller.Core.ConsoleLogger.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string msg);

        void Write(string msg);
    }
}
