using FurnitureManufacturer.Commands.Contracts;

namespace FurnitureManufacturer.Engine.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
