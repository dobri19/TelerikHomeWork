using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Core.Factories.Contracts
{
    public interface ITravellerFactory
    {
        IVehicle CreateBus(int passengerCapacity, decimal pricePerKilometer);

        IVehicle CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood);

        IVehicle CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts);

        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, decimal administrativeCosts);
    }
}
