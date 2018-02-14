using System.Text;
using Traveller.Core.ConsoleLogger.Contracts;

namespace Traveller.Core.ConsoleLogger
{
    public class ConsoleRenderer : IConsoleRenderer
    {
        private readonly StringBuilder builder;

        public ConsoleRenderer()
        {
            this.builder = new StringBuilder();
        }

        public StringBuilder Builder
        {
            get { return this.builder; }
        }
    }
}
