using System.Collections.Generic;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        public IOlympicCommittee committee;
        public IOlympicsFactory factory;

        public Command(IList<string> commandLine, IOlympicCommittee commit, IOlympicsFactory factory)
        {
            this.Committee = commit;
            this.Factory = factory;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters { get; protected set; }

        public IOlympicCommittee Committee { get; }

        public IOlympicsFactory Factory { get; }

        public abstract string Execute();
    }
}
