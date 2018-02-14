using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateJourneyCommand : ICommand
    {
        private readonly IDatabase data;
        private readonly ITravellerFactory factory;
        private readonly Constants constants;

        public CreateJourneyCommand(IDatabase data, ITravellerFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.data.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException(this.constants.FailedParseCreateJourneyErrorMessage);
            }

            var journey = this.factory.CreateJourney(startLocation, destination, distance, vehicle);
            this.data.Journeys.Add(journey);

            return string.Format(this.constants.JourneyCreationMessage, this.data.Journeys.Count - 1);
        }
    }
}
