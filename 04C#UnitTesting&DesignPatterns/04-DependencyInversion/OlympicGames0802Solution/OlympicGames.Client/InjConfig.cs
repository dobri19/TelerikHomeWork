using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.ConsoleWrappers;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using System.Reflection;

namespace OlympicGames.Client
{
    public class InjConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
        }
    }
}
