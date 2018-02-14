using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly Constants constants;

        public ListJourneysCommand(IDatabase data, Constants constants)
        {
            this.data = data;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.data.Journeys;

            if (journeys.Count == 0)
            {
                return this.constants.JourneyNotRegistered;
            }

            return string.Join(Environment.NewLine + this.constants.Delimeters + Environment.NewLine, journeys);
        }
    }
}
