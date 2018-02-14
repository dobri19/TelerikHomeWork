using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamCommandFactoryIsNull()
        {
            // Arrange
            var commandFactoryStub = new Mock<ICommandFactory>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }

        //[TestMethod]
        //public void SetCommandFactory_WhenPassedParamIsValid()
        //{
        //    // Arrange
        //    var commandFactoryStub = new Mock<ICommandFactory>();
        //    var commandParser = new CommandParser(commandFactoryStub.Object);

        //    // Act & Assert
        //    Assert.AreEqual(commandFactoryStub.Object, commandParser.CmdFactory);
        //}
    }
}
