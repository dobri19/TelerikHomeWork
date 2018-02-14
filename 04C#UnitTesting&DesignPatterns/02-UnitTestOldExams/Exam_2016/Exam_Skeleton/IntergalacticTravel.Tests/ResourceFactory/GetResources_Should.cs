using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntergalacticTravel.Tests.ResourceFactory
{
    [TestClass]
    public class GetResources_Should
    {
        [TestMethod]
        [DataRow("create resources gold(20) silver(30) bronze(40)")]
        [DataRow("create resources gold(20) bronze(40) silver(30)")]
        [DataRow("create resources silver(30) bronze(40) gold(20)")]
        [DataRow("create resources silver(30) gold(20) bronze(40)")]
        [DataRow("create resources bronze(40) gold(20) silver(30)")]
        [DataRow("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnNewCreatedResources_WhenCorrectProperties(string command)
        {
            // Arrange
            var bronze = 40u;
            var silver = 30u;
            var gold = 20u;
            var fac = new ResourcesFactory();

            // Act
            var resources = fac.GetResources(command);

            // Assert
            Assert.AreEqual(bronze, resources.BronzeCoins);
            Assert.AreEqual(silver, resources.SilverCoins);
            Assert.AreEqual(gold, resources.GoldCoins);
        }

        [TestMethod]
        [DataRow("create resources x y z")]
        [DataRow("tansta resources a b")]
        [DataRow("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationException_WhenCommandIsInvalid(string command)
        {
            // Arrange
            var fac = new ResourcesFactory();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => fac.GetResources(command));
        }

        [TestMethod]
        [DataRow("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [DataRow("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [DataRow("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenresourceAmountIsLarger(string command)
        {
            // Arrange
            var fac = new ResourcesFactory();

            // Act & Assert
            Assert.ThrowsException<OverflowException>(() => fac.GetResources(command));
        }
    }
}
