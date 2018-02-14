using OlympicGames.Core;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.ConsoleClient
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var committee = new OlympicCommittee();

            var engine = new Engine
                (new CommandParser(),
                new CommandProcessor(),
                new OlympicCommittee(),
                new OlympicsFactory(),
                new IoWrapper(
                    new ConsoleWriter(),
                    new ConsoleReader()
                    )
                );

            engine.Run();
        }
    }
}
