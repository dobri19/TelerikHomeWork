using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Contracts
{
    public interface IJourney
    {
        string StartLocation { get; }

        string Destination { get; }

        int Distance { get; }

        IVehicle Vehicle { get; }

        decimal CalculateTravelCosts();
    }
}
