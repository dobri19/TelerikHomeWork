using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}