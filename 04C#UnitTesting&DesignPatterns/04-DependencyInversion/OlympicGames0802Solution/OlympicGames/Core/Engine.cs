using System;
using OlympicGames.Core.ConsoleWrappers;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IOlympicCommittee committee;
        private readonly IOlympicsFactory factory;
        private readonly IConsoleWrapper ioWrapper;

        private const string Delimiter = "####################";

        public Engine(
            ICommandParser commandParser,
            ICommandProcessor commandProcessor,
            IOlympicCommittee committee,
            IOlympicsFactory factory,
            IConsoleWrapper ioWrapper)
        {
            this.parser = commandParser;
            this.commandProcessor = commandProcessor;
            this.committee = committee;
            this.factory = factory;
            this.ioWrapper = ioWrapper;
        }

        public void Run()
        {
            string commandLine = null;

            while ((commandLine = this.ioWrapper.ReadWithWrapper()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        this.commandProcessor.ProcessSingleCommand(command);
                        this.ioWrapper.WriteWithWrapper(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.ioWrapper.WriteWithWrapper($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
