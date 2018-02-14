using Traveller.Core.Contracts;

namespace Traveller.Core.Decorator
{
    public abstract class EngineDecorator : IEngine
    {
        protected readonly IEngine engine;

        public EngineDecorator(IEngine engine)
        {
            this.engine = engine;
        }

        public abstract void Start();
    }
}
