using System.Text;

namespace Traveller.Core.ConsoleLogger.Contracts
{
    public interface IConsoleRenderer
    {
        StringBuilder Builder { get; }
    }
}
