using System.Collections.Generic;
using Traveller.Commands.Contracts;

namespace Traveller.Core.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandLine);

        IList<string> ParseParameters(string fullCommand);
    }
}
