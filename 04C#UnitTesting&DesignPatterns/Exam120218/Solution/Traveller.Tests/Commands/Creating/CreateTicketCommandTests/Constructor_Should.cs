using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;

namespace Traveller.Tests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamDatabaseIsNull()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryStub = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(null, factoryStub.Object, constants.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamTravellerFactoryIsNull()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryStub = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(dataStub.Object, null, constants.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedParamTravellerConstantsIsNull()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryStub = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(dataStub.Object, factoryStub.Object, null));
        }
    }
}
