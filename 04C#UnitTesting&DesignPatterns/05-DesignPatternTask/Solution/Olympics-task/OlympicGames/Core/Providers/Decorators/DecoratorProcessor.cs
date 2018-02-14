using OlympicGames.Core.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Core.Providers.Decorators
{
    public abstract class DecoratorProcessor : ICommandProcessor
    {
        protected ICommandProcessor processor;
        protected IIoWrapper wrapper;

        public DecoratorProcessor(ICommandProcessor processor, IIoWrapper wrapper)
        {
            this.processor = processor;
            this.wrapper = wrapper;
        }

        public ICollection<ICommand> Commands { get; set; }

        public abstract void ProcessSingleCommand(ICommand command);
    }
}
