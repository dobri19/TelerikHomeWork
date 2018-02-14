using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateTrainCommand(IDatabase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException(this.constants.FailedParseCreateTrainErrorMessage);
            }

            var train = this.factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.data.Vehicles.Add(train);

            return string.Format(this.constants.VehicleCreationMessage, this.data.Vehicles.Count - 1);
        }
    }
}
