using Autofac;
using Autofac.Core;
using System.Reflection;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Decorator;
using Traveller.Core.Factories;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Client
{
    public class InjectConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetAssembly(typeof(IEngine));

            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces();

            builder.RegisterType<Engine>().Named<IEngine>("mainEngine");

            builder.RegisterType<TimingEngine>().As<IEngine>().WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IEngine) && pi.Name == "engine",
                (pi, ctx) => ctx.ResolveNamed<IEngine>("mainEngine"));

            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            builder.RegisterType<Constants>().AsSelf().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<TravellerFactory>().As<ITravellerFactory>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();

            builder.RegisterType<CreateAirplaneCommand>().Named<ICommand>("createairplane");
            builder.RegisterType<CreateBusCommand>().Named<ICommand>("createbus");
            builder.RegisterType<CreateJourneyCommand>().Named<ICommand>("createjourney");
            builder.RegisterType<CreateTicketCommand>().Named<ICommand>("createticket");
            builder.RegisterType<CreateTrainCommand>().Named<ICommand>("createtrain");
            builder.RegisterType<ListJourneysCommand>().Named<ICommand>("listjourneys");
            builder.RegisterType<ListTicketsCommand>().Named<ICommand>("listtickets");
            builder.RegisterType<ListVehiclesCommand>().Named<ICommand>("listvehicles");
        }
    }
}
