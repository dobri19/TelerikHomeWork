using OlympicGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Core.Commands.Decorators
{
    public class LoggerListCommand : ICommand
    {
        private readonly ICommand command;
        private readonly IConsoleWriter writer;

        public LoggerListCommand(ICommand command, IConsoleWriter writer)
        {
            this.command = command;
            this.writer = writer;
        }

        public string Execute(IList<string> commandParameters)
        {
            this.writer.WriteLine("Executing list");
            return this.command.Execute(commandParameters);
        }
    }
}
