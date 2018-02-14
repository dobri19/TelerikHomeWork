using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void CreateWithCommandname()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryMock.Object);
            var command = "createbus 10 0.7";

            // Act
            commandParser.ParseCommand(command);

            // Assert
            commandFactoryMock.Verify((x) => x.Create("createbus"), Times.Exactly(1));
        }
    }
}
