using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using IntergalacticTravel.Contracts;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetUpFields_WhenAreCorrect()
        {
            //Constructor should set up all of the provided fields(owner, galacticMap & location), 
            //when a new TeleportStation is created with valid parameters passed to the constructor.
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            
            // Act
            var teleport = new ExtendedTeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);
            var x = teleport.Owner;
            var y = teleport.Location;
            var z = teleport.GalacticMap;

            // Assert
            //Assert.IsInstanceOfType(teleport, typeof(TeleportStation));
            Assert.AreEqual(ownerStub.Object, x);
            Assert.AreEqual(locationStub.Object, y);
            Assert.AreEqual(galacticMapStub.Object, z);
        }
    }
}
