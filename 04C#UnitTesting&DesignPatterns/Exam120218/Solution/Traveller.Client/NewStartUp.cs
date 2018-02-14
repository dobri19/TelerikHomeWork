using Autofac;
using Traveller.Core.Contracts;

namespace Traveller.Client
{
    public class NewStartUp
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<InjectConfig>();

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Start();
        }
    }
}
