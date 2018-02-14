using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.ConsoleWrappers;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Client
{
    public class InjectionConfig
    {
        public InjectionConfig(ContainerBuilder builder)
        {
            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>();
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
            builder.RegisterType<ConsoleWrapper>().As<IConsoleWrapper>();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>();

            //builder.RegisterType<Engine>().AsSelf().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
        }
    }
}
