using System;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IOlympicsFactory factory;
        private readonly IIoWrapper ioWrapper;

        private readonly IOlympicCommittee committee;

        private const string Delimiter = "####################";

        public Engine(
            ICommandParser commandParser,
            ICommandProcessor commandProcessor,
            IOlympicCommittee committee,
            IOlympicsFactory factory,
            IIoWrapper ioWrapper)
        {
            this.parser = commandParser;
            this.commandProcessor = commandProcessor;
            this.factory = factory;
            this.ioWrapper = ioWrapper;

            this.committee = committee;
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

                    Console.WriteLine("ERROR: {0}", ex.Message);
                }
            }
        }


    }
}
