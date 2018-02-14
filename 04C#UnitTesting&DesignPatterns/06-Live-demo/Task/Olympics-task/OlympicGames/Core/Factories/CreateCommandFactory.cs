using Autofac;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Factories
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
