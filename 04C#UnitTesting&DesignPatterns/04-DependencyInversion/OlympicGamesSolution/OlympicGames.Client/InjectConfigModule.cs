using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.LoggerConsole;
using System.Reflection;

namespace OlympicGames.Client
{
    public class InjectConfigModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
            //    //.Where(x => x.Namespace.Contains("OlympicGames"))
            //    .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>().SingleInstance();
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
        }
    }
}
