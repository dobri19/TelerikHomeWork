using OlympicGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Core.Providers.Decorators
{
    public class CommandProcessorDecorator : ICommandProcessor
    {
        private readonly ICommandProcessor processor;
        private readonly IIoWrapper ioWrapper;

        public CommandProcessorDecorator(ICommandProcessor processor, IIoWrapper ioWrapper)
        {
            this.processor = processor;
            this.ioWrapper = ioWrapper;
        }

        public ICollection<ICommand> Commands => this.processor.Commands;

        public void ProcessSingleCommand(ICommand command)
        {
            this.processor.ProcessSingleCommand(command);

            this.ioWrapper.WriteWithWrapper("Processed command");
            this.ioWrapper.WriteWithWrapper("########################");
        }
    }
}
