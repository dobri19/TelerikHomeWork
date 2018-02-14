using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.NewClient.InjectionConfig;
using System.Reflection;

namespace OlympicGames.NewClient
{
    public class StartUp
    {
        static void Main()
        {
            // Engine resolve using Autofac
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());


            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Run();

            //// Resolve writer
            //builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();

            //var writer = container.Resolve<IConsoleWriter>();
            //writer.WriteLine("Hello from autofac");
        }
    }
}
