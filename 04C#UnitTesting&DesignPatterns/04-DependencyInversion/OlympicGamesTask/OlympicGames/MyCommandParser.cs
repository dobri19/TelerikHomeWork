using OlympicGames.Core.Contracts;

namespace OlympicGames
{
    public class FakeParser : ICommandParser
    {

        public ICommand ParseCommand(string commandLine)
        {
            throw new System.NotImplementedException();
        }
    }
}