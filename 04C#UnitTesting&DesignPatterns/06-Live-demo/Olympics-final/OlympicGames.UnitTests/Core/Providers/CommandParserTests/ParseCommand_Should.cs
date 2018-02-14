using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void InvokeCreateOnCommandFactory()
        {
            // Arrange
            var mockFactory = new Mock<ICommandFactory>();

            var parser = new CommandParser(mockFactory.Object);

            // Act
            parser.ParseCommand("test");

            // Assert
            mockFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
