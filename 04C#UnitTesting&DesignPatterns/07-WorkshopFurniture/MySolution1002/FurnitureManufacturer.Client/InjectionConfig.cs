using Autofac;
using FurnitureManufacturer.Commands;
using FurnitureManufacturer.Commands.Company;
using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Engine.Factories;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Contracts;
using FurnitureManufacturer.Models.Furnitures;
using FurnitureManufacturer.Models.Furnitures.Contracts;
using System.Reflection;

namespace FurnitureManufacturer.Client
{
    public class InjectionConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var assembly = Assembly.GetAssembly(typeof(IFurnitureEngine));
            //var name = Assembly.GetAssembly(typeof(IFurnitureEngine)).GetName();
            //var assembly = Assembly.Load(name);
            //builder.RegisterType<Company>().As<ICompany>();
            //builder.RegisterType<Furniture>().As<IFurniture>();
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            builder.RegisterType<ConsoleRenderer>().As<IRenderer>().SingleInstance();
            builder.RegisterType<CompanyFactory>().As<ICompanyFactory>().SingleInstance();
            builder.RegisterType<FurnitureFactory>().As<IFurnitureFactory>().SingleInstance();
            //builder.RegisterAssemblyTypes(currentAssembly)
            //       .AsImplementedInterfaces();

            builder.RegisterType<FurnitureEngine>().As<IFurnitureEngine>().SingleInstance();
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

            //builder.RegisterType<FurnitureEngine>().As<IFurnitureEngine>().SingleInstance();
        }
    }
}
