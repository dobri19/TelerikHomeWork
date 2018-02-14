using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        public Command(IOlympicCommittee committee, IOlympicsFactory factory, IList<string> commandLine)
        {
            this.Committee = committee;
            this.Factory = factory;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters { get; protected set; }

        public IOlympicCommittee Committee { get; }

        public IOlympicsFactory Factory { get; }

        public abstract string Execute();
    }
}
