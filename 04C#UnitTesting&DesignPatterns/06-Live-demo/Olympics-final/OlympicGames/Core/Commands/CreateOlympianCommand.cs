using System;
using System.Collections.Generic;
using System.Linq;

using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Commands
{
    public abstract class CreateOlympianCommand : Command
    {
        public CreateOlympianCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected string FirstName { get; private set; }

        protected string LastName { get; private set; }

        protected string Country { get; private set; }

        public override string Execute(IList<string> commandParameters)
        {
            commandParameters.ValidateIfNull();

            if (commandParameters.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.FirstName = commandParameters[1];
            this.LastName = commandParameters[2];
            this.Country = commandParameters[3];

            commandParameters = commandParameters.Skip(4).ToList();

            var olympian = this.CreatePerson(commandParameters);

            this.Committee.Olympians.Add(olympian);

            return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        }

        protected abstract IOlympian CreatePerson(IList<string> commandParameters);
    }
}
