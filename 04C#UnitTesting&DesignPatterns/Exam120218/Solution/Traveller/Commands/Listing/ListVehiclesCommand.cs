using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly Constants constants;

        public ListVehiclesCommand(IDatabase data, Constants constants)
        {
            this.data = data;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.data.Vehicles;

            if (vehicles.Count == 0)
            {
                return this.constants.VehiclesNotReristered;
            }

            return string.Join(Environment.NewLine + this.constants.Delimeters + Environment.NewLine, vehicles);
        }
    }
}
