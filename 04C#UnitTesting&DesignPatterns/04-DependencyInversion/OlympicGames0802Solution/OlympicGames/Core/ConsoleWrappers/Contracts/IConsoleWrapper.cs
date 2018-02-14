namespace OlympicGames.Core.ConsoleWrappers
{
    public interface IConsoleWrapper
    {
        void WriteWithWrapper(string msg);

        string ReadWithWrapper();
    }
}
