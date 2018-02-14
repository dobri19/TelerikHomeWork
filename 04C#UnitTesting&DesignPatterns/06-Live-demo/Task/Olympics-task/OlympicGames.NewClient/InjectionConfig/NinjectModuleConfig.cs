using Ninject.Modules;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.NewClient.InjectionConfig
{
    public class NinjectModuleConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandParser>().To<CommandParser>();
        }
    }
}
