using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using IntergalacticTravel.Contracts;
using System.Collections.Generic;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestClass]
    public class TeleportUnit_Should
    {
        [TestMethod]
        public void Throw_ArgumentNullException_When_UnitToTeleportIsNull()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var locTargeStub = new Mock<ILocation>();

            var teleport = new TeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => teleport.TeleportUnit(null, locTargeStub.Object));
        }

        [TestMethod]
        public void Throw_ArgumentNullException_When_LocationToTeleportIsNull()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            var unitStub = new Mock<IUnit>();

            var teleport = new TeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => teleport.TeleportUnit(unitStub.Object, null));
        }

        [TestMethod]
        public void Throw_TeleportOutOfRangeException_When_UnitGoesToDifferentPlanet()
        {
            //TeleportUnit should throw TeleportOutOfRangeException, with a message that contains the string 
            //"unitToTeleport.CurrentLocation", when а unit is trying to use the TeleportStation 
            //from a distant location(another planet for example).

            // Arrange
            var planet1 = "Venera";
            var planet2 = "Milovska";
            var gala1 = "MilkShake";
            var gala2 = "Andromeda";

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var unitStub = new Mock<IUnit>();
            var locTargeStub = new Mock<ILocation>();

            locationStub.SetupGet(x => x.Planet.Name).Returns(planet1);
            locationStub.SetupGet(x => x.Planet.Galaxy.Name).Returns(gala1);

            unitStub.SetupGet(x => x.CurrentLocation.Planet.Name).Returns(planet2);
            unitStub.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(gala2);

            var teleport = new ExtendedTeleportStation(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            // Act & Assert
            Assert.ThrowsException<TeleportOutOfRangeException>(() => teleport.TeleportUnit(unitStub.Object, locTargeStub.Object));
        }

        [TestMethod]
        public void ThrowInvalidTeleportationLocationException_WhenTryingToTeleportUnitToLocationWhichIsAlreadyTakenByAnotherUnit()
        {
            // Arrange
            var expectedExceptionMessage = "units will overlap";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.ThrowsException<InvalidTeleportationLocationException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(actualExceptionMessage, expectedExceptionMessage);
        }

        [TestMethod]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportUnitToGalaxyWhichDoesntExistInTheGalacticMapOfTheTeleportStation()
        {
            // Arrange
            var expectedExceptionMessage = "Galaxy";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("DifferentGalaxyName");

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.ThrowsException<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(actualExceptionMessage, expectedExceptionMessage);
        }

        [TestMethod]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportUnitToPlanetWhichDoesntExistInTheGalacticMapOfTheTeleportStation()
        {
            // Arrange
            var expectedExceptionMessage = "Planet";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns("DifferentPlanetName");
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.ThrowsException<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(actualExceptionMessage, expectedExceptionMessage);
        }

        [TestMethod]
        public void ThrowInsufficientResourcesException_WhenTryingToTeleportUnitButTheServiceCostsMoreThanTheUnitCurrentAvailableResources()
        {
            // Arrange
            var expectedExceptionMessage = "FREE LUNCH";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.ThrowsException<InsufficientResourcesException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(actualExceptionMessage, expectedExceptionMessage);
        }

        [TestMethod]
        public void RequestPaymentFromTheUnitThatIsBeingTeleportedWithTheAmountOfPathCost_WhenTheValidationsPassSuccessfullyAndTheUnitsIsReadyForTeleportation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.Verify(x => x.Pay(pathMock.Object.Cost), Times.Once());
        }

        [TestMethod]
        public void ObtainPaymentFromTheUnitThatIsBeingTeleportedWithTheAmountOfPathCost_WhenTheValidationsPassSuccessfullyAndTheUnitsIsReadyForTeleportation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);
            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            var expectedBronzeCoins = initialTeleportStationResources.BronzeCoins + pathMock.Object.Cost.BronzeCoins;
            var expectedSilverCoins = initialTeleportStationResources.SilverCoins + pathMock.Object.Cost.SilverCoins;
            var expectedGoldCoins = initialTeleportStationResources.GoldCoins + pathMock.Object.Cost.GoldCoins;

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);
            var actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            var actualSilverCoins = teleportStation.Resources.SilverCoins;
            var actualGoldcoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldcoins);
        }

        [TestMethod]
        public void SetTheUnitToTeleportPreviousLocationToHisCurrentLocation_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.VerifySet(x => x.PreviousLocation = x.CurrentLocation, Times.Once());
        }

        [TestMethod]
        public void SetTheUnitToTeleportCurrentLocationToTargetLocation_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.VerifySet(x => x.CurrentLocation = targetLocationMock.Object, Times.Once());
        }

        [TestMethod]
        public void AddTheUnitToTeleportToTheListOfUnitsOfTheTargetPlanet_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var targetLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            targetLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(planetaryUnitMock.Object)
                .Callback(
                    () =>
                        targetLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var targetLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            targetLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(targetLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetaryUnitsCollectionMock.Object);

            var currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(unitToTeleportMock.Object)
                .Callback(
                    () =>
                        currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var currentUnitLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsCollectionMock.Object);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            targetLocationPlanetaryUnitsCollectionMock.Verify(x => x.Add(unitToTeleportMock.Object), Times.Once());
        }

        [TestMethod]
        public void RemoveTheUnitToTeleportFromTheListOfUnitsOfItsCurrentPlanet_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var targetLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            targetLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(planetaryUnitMock.Object)
                .Callback(
                    () =>
                        targetLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var targetLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            targetLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(targetLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetaryUnitsCollectionMock.Object);

            var currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(unitToTeleportMock.Object)
                .Callback(
                    () =>
                        currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var currentUnitLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsCollectionMock.Object);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            currentUnitLocationPlanetaryUnitsCollectionMock.Verify(x => x.Remove(unitToTeleportMock.Object), Times.Once());
        }
    }
}
