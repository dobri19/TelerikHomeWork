using Traveller.Commands.Contracts;

namespace Traveller.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}
