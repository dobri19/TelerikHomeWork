using Autofac;
using FurnitureManufacturer.Engine.Contracts;

namespace FurnitureManufacturer.Client
{
    public sealed class StartUp
    {
        public static void Main()
        {
            var containerConfig = new AutofacConfig();
            var container = containerConfig.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
