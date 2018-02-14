using System.Collections.Generic;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        private readonly IOlympicCommittee committee;
        private readonly IOlympicsFactory factory;

        public Command(IOlympicCommittee committee, IOlympicsFactory factory, IList<string> commandLine)
        {
            this.committee = committee;
            this.factory = factory;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters { get; protected set; }

        public IOlympicCommittee Committee { get { return this.committee; } }

        public IOlympicsFactory Factory { get { return this.factory; } }

        public abstract string Execute();
    }
}
