using Autofac;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;

namespace Traveller.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand Create(string cmdName)
        {
            return this.container.ResolveNamed<ICommand>(cmdName);
        }
    }
}
