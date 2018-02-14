using System.Collections.Generic;

namespace OlympicGames.Core.Contracts
{
    public interface ICommandProcessor 
    {
        ICollection<ICommand> Commands { get; }

        void ProcessSingleCommand(ICommand command);
    }
}
