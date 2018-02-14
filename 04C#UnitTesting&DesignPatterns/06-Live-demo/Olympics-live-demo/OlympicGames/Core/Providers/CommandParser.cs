using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using System;
using System.Linq;
using System.Reflection;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory cmdFactory;

        public CommandParser(ICommandFactory cmdFactory)
        {
            this.cmdFactory = cmdFactory;
        }

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];

            var command = this.cmdFactory.Create(commandName);
            return command;
        }
    }
}
