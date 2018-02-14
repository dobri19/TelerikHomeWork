using Autofac;
using FurnitureManufacturer.Commands;
using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Engine.Factories;
using FurnitureManufacturer.Interfaces.Engine;
using System.Reflection;

namespace FurnitureManufacturer.Client.InjectionConfig
{
    public sealed class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var currentAssembly = Assembly.Load("FurnitureManufacturer");

            builder.RegisterType<ConsoleRenderer>().As<IRenderer>().SingleInstance();
            builder.RegisterType<CompanyFactory>().As<ICompanyFactory>().SingleInstance();
            builder.RegisterType<FurnitureFactory>().As<IFurnitureFactory>().SingleInstance();
            //builder.RegisterAssemblyTypes(currentAssembly)
            //       .AsImplementedInterfaces();

            builder.RegisterType<FurnitureEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Constants>().AsSelf().SingleInstance();
            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();

            builder.RegisterType<CreateChairCommand>().Named<ICommand>("createchair");
            builder.RegisterType<CreateCompanyCommand>().Named<ICommand>("createcompany");
            builder.RegisterType<CreateTableCommand>().Named<ICommand>("createtable");
            builder.RegisterType<AddFurnitureToCompanyCommand>().Named<ICommand>("addfurnituretocompany");
            builder.RegisterType<FindFurnitureFromCompanyCommand>().Named<ICommand>("findfurniturefromcompany");
            builder.RegisterType<RemoveFurnitureFromCompanyCommand>().Named<ICommand>("removefurniturefromcompany");
            builder.RegisterType<ShowCompanyCatalogCommand>().Named<ICommand>("showcompanycatalog");

            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
        }
    }
}
