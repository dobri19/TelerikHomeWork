using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateTicketCommand(IDatabase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data ?? throw new ArgumentNullException();
            this.factory = factory ?? throw new ArgumentNullException();
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.data.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException(this.constants.FailedParseErrorMessage);
            }

            var ticket = this.factory.CreateTicket(journey, administrativeCosts);
            this.data.Tickets.Add(ticket);

            return string.Format(this.constants.TicketCreationMessage, this.data.Tickets.Count - 1);
        }
    }
}
