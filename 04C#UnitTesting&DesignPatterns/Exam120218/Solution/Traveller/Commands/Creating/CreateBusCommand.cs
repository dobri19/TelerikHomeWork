using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateBusCommand(IDatabase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException(this.constants.FailedParseCreateBusErrorMessage);
            }

            var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);

            this.data.Vehicles.Add(bus);

            return string.Format(this.constants.VehicleCreationMessage, this.data.Vehicles.Count - 1);
        }
    }
}
