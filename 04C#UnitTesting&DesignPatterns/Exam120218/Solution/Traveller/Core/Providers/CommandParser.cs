using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory cmdFactory;

        public CommandParser(ICommandFactory cmdFactory)
        {
            this.cmdFactory = cmdFactory ?? throw new ArgumentNullException();
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];

            var command = this.CmdFactory.Create(commandName);

            return command;
        }

        protected ICommandFactory CmdFactory => cmdFactory;

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}

