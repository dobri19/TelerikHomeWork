using Autofac;
using FurnitureManufacturer.Engine.Contracts;
using System.Reflection;

namespace FurnitureManufacturer.Client
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            //builder.RegisterModule<InjectionConfig>();
            builder.RegisterModule(new InjectionConfig());

            var container = builder.Build();

            var engine = container.Resolve<IFurnitureEngine>();

            engine.Start();
        }
    }
}
