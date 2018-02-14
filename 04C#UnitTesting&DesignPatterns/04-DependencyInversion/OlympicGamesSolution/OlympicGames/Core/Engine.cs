using System;
using OlympicGames.Core.Contracts;
using OlympicGames.LoggerConsole;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IOlympicsFactory factory;
        private readonly IOlympicCommittee committee;

        private const string Delimiter = "####################";

        private readonly ILogger log;

        public Engine(
            ILogger log,
            ICommandParser commandParser,
            ICommandProcessor commandProcessor,
            IOlympicCommittee committee,
            IOlympicsFactory factory)
        {
            this.log = log;
            this.parser = commandParser;
            this.commandProcessor = commandProcessor;
            this.factory = factory;
            this.committee = committee;
        }

        public void Run()
        {
            string commandLine = null;

            while ((commandLine = log.Read()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        this.commandProcessor.ProcessSingleCommand(command);
                        log.Write(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    log.WriteFormat("ERROR: {0}", ex.Message);
                }
            }
        }
    }
}
