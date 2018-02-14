using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.ConsoleWrappers;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using System.Reflection;

namespace OlympicGames.Client
{
    public class NewStartUp
    {
        public static void Main()
        {
            #region Variant 1
            //var builder = new ContainerBuilder();

            //builder.RegisterType<CommandParser>().As<ICommandParser>();
            //builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            //builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>();
            //builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
            //builder.RegisterType<ConsoleWrapper>().As<IConsoleWrapper>();
            //builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();
            //builder.RegisterType<ConsoleReader>().As<IConsoleReader>();

            //builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            //var container = builder.Build();

            //var engine = container.Resolve<IEngine>();

            //engine.Run();
            #endregion

            #region Variant 2
            //var builder = new ContainerBuilder();

            //var injectionConfig = new InjectionConfig(builder);

            //var container = builder.Build();

            //var engine = container.Resolve<Engine>();

            //engine.Run();
            #endregion

            #region Variant 3
            //var builder = new ContainerBuilder();

            //// var 01
            ////builder.RegisterModule<InjectConfig>();

            //// var 02
            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            //var container = builder.Build();

            //var engine = container.Resolve<IEngine>();

            //engine.Run();
            #endregion

            #region Variant 3
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
            #endregion
        }
    }
}
