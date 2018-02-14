using Autofac;
using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine.Contracts;

namespace FurnitureManufacturer.Engine.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IComponentContext container;

        public CommandsFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
