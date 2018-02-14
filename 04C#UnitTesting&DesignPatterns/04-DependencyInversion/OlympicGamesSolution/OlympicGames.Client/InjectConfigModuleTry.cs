using Autofac;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Olympics;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Client
{
    class InjectConfigModuleTry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Boxer>().As<IBoxer>().SingleInstance();
            builder.RegisterType<Sprinter>().As<ISprinter>().SingleInstance();

            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>().SingleInstance();
        }
    }
}
