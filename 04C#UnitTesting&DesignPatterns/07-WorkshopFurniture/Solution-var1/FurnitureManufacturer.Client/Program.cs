using Autofac;
using FurnitureManufacturer.Client.InjectionConfig;

namespace FurnitureManufacturer.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
