using Autofac;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using System.Reflection;
using System.Configuration;
using OlympicGames.Core.Commands.Decorators;
using OlympicGames.Core.Providers;
using OlympicGames.Core.Factories;
using OlympicGames.Core;

namespace OlympicGames.NewClient.InjectionConfig
{
    public class AutofacModuleConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
            //   .Where(x => x.Namespace.Contains("Factories") ||
            //               x.Namespace.Contains("Providers") ||
            //               x.Namespace.Contains("Core") ||
            //               x.Name.EndsWith("Engine"))
            //   .AsImplementedInterfaces()
            //   .SingleInstance();

            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance();
            builder.RegisterType<IoWrapper>().As<IIoWrapper>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();


            var isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("internalList");
                builder.RegisterType<LoggerListCommand>().Named<ICommand>("listolympians")
                    .WithParameter
                    (
                        (pi, ctx) => pi.Name == "command",
                        (pi, ctx) => ctx.ResolveNamed<ICommand>("internalList")
                    );
            }
            else
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians");
            }

            builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer");
            builder.RegisterType<CreateSprinterCommand>().Named<ICommand>("createsprinter");
        }
    }
}
