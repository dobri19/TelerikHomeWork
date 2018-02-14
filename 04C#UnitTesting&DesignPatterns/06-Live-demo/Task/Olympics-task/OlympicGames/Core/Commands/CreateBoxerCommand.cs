using System;
using System.Collections.Generic;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand, ICommand
    {
        private string category;
        private int wins;
        private int losses;

        public CreateBoxerCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected override IOlympian CreatePerson(IList<string> commandParameters)
        {
            if (commandParameters.Count != 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.category = commandParameters[0];

            bool checkWins = int.TryParse(commandParameters[1], out this.wins);
            bool checkLosses = int.TryParse(commandParameters[2], out this.losses);

            if (!checkWins || !checkLosses)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }

            return this.Factory.CreateBoxer(this.FirstName, this.LastName, this.Country, this.category, this.wins, this.losses);
        }
    }
}
