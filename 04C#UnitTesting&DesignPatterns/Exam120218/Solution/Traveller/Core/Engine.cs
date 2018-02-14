using System;
using Traveller.Core.ConsoleLogger.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandFactory factory;
        private readonly Constants constants;
        private readonly IConsoleLogger consoleLogger;
        private readonly IConsoleRenderer consoleRenderer;

        public Engine(ICommandParser commandParser, ICommandFactory factory, Constants constants,
            IConsoleLogger consoleLogger, IConsoleRenderer consoleRenderer)
        {
            this.commandParser = commandParser ?? throw new ArgumentNullException();
            this.factory = factory ?? throw new ArgumentNullException();
            this.constants = constants ?? throw new ArgumentNullException();
            this.consoleLogger = consoleLogger ?? throw new ArgumentNullException();
            this.consoleRenderer = consoleRenderer ?? throw new ArgumentNullException();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = consoleLogger.ReadLineWithLogger();

                    if (commandAsString.ToLower() == this.constants.TerminationCommand.ToLower())
                    {
                        consoleLogger.WriteWithLogger(this.consoleRenderer.Builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.consoleRenderer.Builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException(this.constants.NullCommandExceptionMessage);
            }

            var command = commandParser.ParseCommand(commandAsString);
            var parameters = commandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);

            this.consoleRenderer.Builder.AppendLine(executionResult);
        }
    }
}
