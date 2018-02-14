using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using System;
using System.Linq;
using System.Reflection;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];
            var parameters = lineParameters.Skip(1);

            var typeInfo = FindCommand(commandName);
            var command = Activator.CreateInstance(typeInfo, new OlympicCommittee(), new OlympicsFactory(), parameters.ToList()) as ICommand;
            return command;
        }

        private TypeInfo FindCommand(string commandName)
        {
            Assembly commandAssembly = Assembly.GetAssembly(typeof(ICommand));

            var commandType = commandAssembly.DefinedTypes
                .Where(x => x.ImplementedInterfaces.Any(y => y == typeof(ICommand)))
                .Where(x => !x.IsAbstract)
                .SingleOrDefault(x => x.Name.ToLower() == (commandName.ToLower() + "command"));

            if (commandType == null)
            {
                throw new ArgumentException("No such command implemented! Consider implementing it before using!");
            }

            return commandType;
        }
    }
}
