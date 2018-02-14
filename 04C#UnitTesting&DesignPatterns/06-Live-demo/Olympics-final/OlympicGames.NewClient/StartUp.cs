using Autofac;
using OlympicGames.Core.Contracts;
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

            //// Resolve writer EXAMPLE
            //builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();

            //var writer = container.Resolve<IConsoleWriter>();
            //writer.WriteLine("Hello from autofac");
        }
    }
}
