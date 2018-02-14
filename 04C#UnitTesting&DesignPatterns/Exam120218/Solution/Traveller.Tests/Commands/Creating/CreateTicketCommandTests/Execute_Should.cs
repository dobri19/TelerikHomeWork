using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Tests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenPassedParamCanNotBeParsed()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryStub = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            var command = new CreateTicketCommand(dataStub.Object, factoryStub.Object, constants.Object);

            var journeys = new List<IJourney>();
            var mockJourney = new Mock<IJourney>();
            journeys.Add(mockJourney.Object);
            dataStub.Setup((x) => x.Journeys).Returns(journeys);
            var param = new List<string>() { "a", "z" };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute(param));
        }

        [TestMethod]
        public void CreateTicket_WhenPassedParamCanBeParsed()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            var command = new CreateTicketCommand(dataStub.Object, factoryMock.Object, constants.Object);

            var journeys = new List<IJourney>();
            var mockJourney = new Mock<IJourney>();
            journeys.Add(mockJourney.Object);

            var tickets = new List<ITicket>();
            var mockTicket = new Mock<ITicket>();

            dataStub.Setup((x) => x.Journeys).Returns(journeys);
            dataStub.Setup((x) => x.Tickets).Returns(tickets);
            var administrativeCosts = 2;
            var param = new List<string>() { "0", "2" };

            constants.Setup((x) => x.TicketCreationMessage).Returns("message");

            // Act
            command.Execute(param);

            // Act & Assert
            factoryMock.Verify((x) => x.CreateTicket(mockJourney.Object, administrativeCosts), Times.Exactly(1));
        }

           [TestMethod]
        public void AddTicket_WhenPassedParamCanBeParsed()
        {
            // Arrange
            var dataStub = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var constants = new Mock<Constants>();

            var command = new CreateTicketCommand(dataStub.Object, factoryMock.Object, constants.Object);

            var journeys = new List<IJourney>();
            var mockJourney = new Mock<IJourney>();
            journeys.Add(mockJourney.Object);

            var tickets = new List<ITicket>();
            var mockTicket = new Mock<ITicket>();

            dataStub.Setup((x) => x.Journeys).Returns(journeys);
            dataStub.Setup((x) => x.Tickets).Returns(tickets);

            var param = new List<string>() { "0", "2" };

            constants.Setup((x) => x.TicketCreationMessage).Returns("message");

            // Act
            command.Execute(param);

            // Act & Assert
            Assert.AreEqual(1, dataStub.Object.Tickets.Count);
        }
    }
}
