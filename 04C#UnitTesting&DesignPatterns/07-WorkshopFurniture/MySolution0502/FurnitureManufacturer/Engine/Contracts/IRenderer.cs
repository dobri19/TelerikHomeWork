using System.Collections.Generic;

namespace FurnitureManufacturer.Engine.Contracts
{
    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}
