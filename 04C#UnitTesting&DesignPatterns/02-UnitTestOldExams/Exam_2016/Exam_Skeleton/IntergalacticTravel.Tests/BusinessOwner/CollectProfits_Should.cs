using IntergalacticTravel.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.BusinessOwner
{
    [TestClass]
    public class CollectProfits_Should
    {
        [TestMethod]
        public void IncreaseTheOwnerResourcesByTheTotalAmountOfResourcesGeneratedFromTheTeleportStationsInHisPossession_WhenSuchStationsExist()
        {
            var ownerId = 71;
            var ownerNickName = "Mecho";
            var teleportStationsCollection = new List<ITeleportStation>();
            var owner = new IntergalacticTravel.BusinessOwner(ownerId, ownerNickName, teleportStationsCollection);

            var firstTeleportStationResourcesMock = new Mock<IResources>();
            firstTeleportStationResourcesMock.Setup(x => x.BronzeCoins).Returns(200);
            firstTeleportStationResourcesMock.Setup(x => x.SilverCoins).Returns(300);
            firstTeleportStationResourcesMock.Setup(x => x.GoldCoins).Returns(400);
            var firstTeleportStationMock = new Mock<ITeleportStation>();
            firstTeleportStationMock.Setup(x => x.PayProfits(owner)).Returns(firstTeleportStationResourcesMock.Object);

            var secondTeleportStationResourcesMock = new Mock<IResources>();
            secondTeleportStationResourcesMock.Setup(x => x.BronzeCoins).Returns(200);
            secondTeleportStationResourcesMock.Setup(x => x.SilverCoins).Returns(300);
            secondTeleportStationResourcesMock.Setup(x => x.GoldCoins).Returns(400);
            var secondTeleportStationMock = new Mock<ITeleportStation>();
            secondTeleportStationMock.Setup(x => x.PayProfits(owner)).Returns(secondTeleportStationResourcesMock.Object);

            owner.TeleportStations.Add(firstTeleportStationMock.Object);
            owner.TeleportStations.Add(secondTeleportStationMock.Object);

            var expectedBronzeCoins = firstTeleportStationResourcesMock.Object.BronzeCoins + secondTeleportStationResourcesMock.Object.BronzeCoins;
            var expectedSilverCoins = firstTeleportStationResourcesMock.Object.SilverCoins + secondTeleportStationResourcesMock.Object.SilverCoins;
            var expectedGoldCoins = firstTeleportStationResourcesMock.Object.GoldCoins + secondTeleportStationResourcesMock.Object.GoldCoins;

            // Act
            owner.CollectProfits();

            var actualBronzeCoins = owner.Resources.BronzeCoins;
            var actualSilverCoins = owner.Resources.SilverCoins;
            var actualGoldCoins = owner.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }
    }
}
