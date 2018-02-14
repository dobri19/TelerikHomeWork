using OlympicGames.Core;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.Core.Providers.Decorators;
using System;
using System.Configuration;

namespace OlympicGames.ConsoleClient
{
    public class StartUp
    {
        public static void Main(string[] args)
        {


            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var ioWrapper = new IoWrapper(writer, reader);
            var cmdParser = new CommandParser();

            var cmdProcessor = new CommandProcessor();

            var decorator = new CommandProcessorDecorator(cmdProcessor, ioWrapper);
            var committee = new OlympicCommittee();
            var factory = new OlympicsFactory();


            var engine = new Engine
                (cmdParser,
                decorator,
                committee,
                factory,
                ioWrapper);

            engine.Run();
        }
    }
}
