using Autofac;
using OlympicGames.Core.Contracts;
using System.Reflection;

namespace OlympicGames.NewClient
{
    public class StartUp
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Run();
        }
    }
}
