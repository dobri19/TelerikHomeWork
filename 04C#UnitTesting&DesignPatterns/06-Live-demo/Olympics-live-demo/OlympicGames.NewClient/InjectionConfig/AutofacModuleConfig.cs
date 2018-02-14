using Autofac;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using System.Configuration;
using System.Reflection;

namespace OlympicGames.NewClient.InjectionConfig
{
    public class AutofacModuleConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .Where(x=>x.Namespace.Contains("Factories") ||
                            x.Namespace.Contains("Providers") ||
                            x.Name.EndsWith("Engine"))
                .AsImplementedInterfaces()
                .SingleInstance();

            var isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians");

            }
            else
            {

            }

            builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer");

        }
    }
}
