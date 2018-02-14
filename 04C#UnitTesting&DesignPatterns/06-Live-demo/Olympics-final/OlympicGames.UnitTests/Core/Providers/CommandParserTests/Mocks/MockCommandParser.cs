using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.UnitTests.Core.Providers.CommandParserTests.Mocks
{
    public class MockCommandParser : CommandParser
    {

        public ICommandFactory ExposedCommandFactory => this.CmdFactory;

        public MockCommandParser(ICommandFactory cmdFactory) 
            : base(cmdFactory)
        {
        }
    }
}
