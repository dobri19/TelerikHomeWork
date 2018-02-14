using System;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers.Decorators
{
    public class LoggerCommandProcessor : DecoratorProcessor
    {
        public LoggerCommandProcessor(ICommandProcessor processor, IIoWrapper wrapper)
            : base(processor, wrapper)
        {
        }

        public override void ProcessSingleCommand(ICommand command)
        {
            this.processor.ProcessSingleCommand(command);
            this.wrapper.WriteWithWrapper("####################");
            this.wrapper.WriteWithWrapper($"-- [{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")}] Processed Command--|");
        }
    }
}
