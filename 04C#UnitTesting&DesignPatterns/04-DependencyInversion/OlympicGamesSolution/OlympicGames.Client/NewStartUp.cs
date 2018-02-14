using Autofac;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Client
{
    public class NewStartUp
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            var injectionConfig = new InjectConfigModule();
            builder.RegisterModule<InjectConfigModule>();

            //var injectionConfig2 = new InjectConfigModule();
            //builder.RegisterModule<InjectConfigModuleTry>();

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}
