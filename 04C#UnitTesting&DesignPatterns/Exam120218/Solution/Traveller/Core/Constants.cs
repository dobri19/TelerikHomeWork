namespace Traveller.Core
{
    public class Constants
    {
        public virtual string FailedParseErrorMessage => "Failed to parse CreateTicket command parameters.";
        public virtual string TicketCreationMessage => "Ticket with ID {0} was created.";

        public virtual string FailedParseCreateAirplaneErrorMessage => "Failed to parse CreateAirplane command parameters.";
        public virtual string VehicleCreationMessage => "Vehicle with ID {0} was created.";

        public virtual string FailedParseCreateBusErrorMessage => "Failed to parse CreateBus command parameters.";

        public virtual string FailedParseCreateTrainErrorMessage => "Failed to parse CreateTrain command parameters.";

        public virtual string FailedParseCreateJourneyErrorMessage => "Failed to parse CreateTrain command parameters.";
        public virtual string JourneyCreationMessage => "Ticket with ID {0} was created.";
        public virtual string Delimeters => "####################";
        public virtual string JourneyNotRegistered => "There are no registered journeys.";
        public virtual string VehiclesNotReristered => "There are no registered vehicles.";
        public virtual string TicketNotReristered => "There are no registered tickets.";

        public virtual string WrongStartingLocation => "The StartingLocation's length cannot be less than 5 or more than 25 symbols long.";

        public virtual string TerminationCommand => "Exit";
        public virtual string NullProvidersExceptionMessage => "cannot be null.";
        public virtual string NullCommandExceptionMessage => "Command cannot be null or empty.";
    }
}
