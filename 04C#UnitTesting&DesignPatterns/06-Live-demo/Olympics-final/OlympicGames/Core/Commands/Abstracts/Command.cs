using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        public Command(IOlympicCommittee committee, IOlympicsFactory factory)
        {
            this.Committee = committee;
            this.Factory = factory;
        }

        public IOlympicCommittee Committee { get; }

        public IOlympicsFactory Factory { get; }

        public abstract string Execute(IList<string> commandParameters);
    }
}
