using Autofac;
using FurnitureManufacturer.Engine.Contracts;

namespace FurnitureManufacturer
{
    public sealed class Startup
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
