using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.UnitTests.Core.Providers.CommandParserTests.Mocks;
using System;

namespace OlympicGames.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenCmdFactoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }

        [TestMethod]
        public void SetsTheRightFactoryToProperty()
        {
            // Arrange, Act
            var stubFactory = new Mock<ICommandFactory>();
            var parser = new MockCommandParser(stubFactory.Object);

            // Assert
            Assert.AreSame(stubFactory.Object, parser.ExposedCommandFactory);
        }
    }
}
