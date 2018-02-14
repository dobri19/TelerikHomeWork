using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly Constants constants;

        public ListTicketsCommand(IDatabase data, Constants constants)
        {
            this.data = data;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = this.data.Tickets;

            if (tickets.Count == 0)
            {
                return this.constants.TicketNotReristered;
            }

            return string.Join(Environment.NewLine + this.constants.Delimeters + Environment.NewLine, tickets);
        }
    }
}
