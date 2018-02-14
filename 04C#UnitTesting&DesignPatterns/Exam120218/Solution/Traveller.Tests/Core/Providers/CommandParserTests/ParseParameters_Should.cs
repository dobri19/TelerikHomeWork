using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnNewEmptyList_WhenParamsAreZero()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryMock.Object);
            var command = "createbus";

            // Act
            var list = commandParser.ParseParameters(command);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ReturnCorrectList_WhenParamsAreValid()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandParser = new CommandParser(commandFactoryMock.Object);
            var command = "createbus 10 0.7";
            var listExpected = new List<string>() { "10", "0.7" };
            // Act
            var list = commandParser.ParseParameters(command);

            // Assert
            Assert.AreEqual(listExpected[0], list[0]);
            Assert.AreEqual(listExpected[1], list[1]);
            Assert.AreEqual(2, list.Count);
        }
    }
}
