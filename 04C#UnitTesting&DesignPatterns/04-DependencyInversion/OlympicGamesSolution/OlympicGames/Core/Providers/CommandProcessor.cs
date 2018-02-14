using System;
using System.Collections.Generic;
using System.Linq;
using OlympicGames.Core.Contracts;
using OlympicGames.LoggerConsole;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        //private static CommandProcessor instance;
        public ILogger log;

        public CommandProcessor(ILogger log)
        {
            this.log = log;
            this.Commands = new List<ICommand>();
        }

        //public static CommandProcessor Instance {
        //    get
        //    {
        //        if(instance == null)
        //        {
        //            instance = new CommandProcessor();
        //        }

        //        return instance;
        //    }
        //}

        public ICollection<ICommand> Commands { get; private set; }

        public void Add(ICommand command)
        {
            this.Commands.Add(command);
        }

        public void ProcessCommands()
        {
            foreach (var command in this.Commands)
            {
                var result = command.Execute();
                var normalizedOutput = this.NormalizeOutput(result);
                log.Write(normalizedOutput);
            }
        }

        public void ProcessSingleCommand(ICommand command)
        {
            var result = command.Execute();
            var normalizedOutput = this.NormalizeOutput(result);
            log.Write(normalizedOutput);
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}