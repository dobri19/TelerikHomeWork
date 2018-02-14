using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestClass]
    public class GetUnit_Should
    {
        [TestMethod]
        public void ReturnNewProcyon_WhenValidCommandIsPassed()
        {
            // Arrange
            var fac = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Procyon Dojo 12";

            // Act
            var unit = fac.GetUnit(command);

            // Assert
            Assert.IsInstanceOfType(unit, typeof(Procyon));
        }

        [TestMethod]
        public void ReturnNewLuyten_WhenValidCommandIsPassed()
        {
            // Arrange
            var fac = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Luyten Zaza 123";

            // Act
            var unit = fac.GetUnit(command);

            // Assert
            Assert.IsInstanceOfType(unit, typeof(Luyten));
        }

        [TestMethod]
        public void ReturnNewLacaille_WhenValidCommandIsPassed()
        {
            // Arrange
            var fac = new IntergalacticTravel.UnitsFactory();
            var command = "create unit Lacaille Joja 01";

            // Act
            var unit = fac.GetUnit(command);

            // Assert
            Assert.IsInstanceOfType(unit, typeof(Lacaille));
        }

        [TestMethod]
        [DataRow("create unit Zarioa Joja --")]
        [DataRow("create zoro Zarioa Joja")]
        [DataRow("123 zoro Zarioa Joja 456")]
        public void ThrowInvalidUnitCreationCommandException_WhenCommandIsNotValid(string command)
        {
            // Arrange
            var fac = new UnitsFactory();

            // Act&&Assert
            Assert.ThrowsException<InvalidUnitCreationCommandException>(() => fac.GetUnit(command));
        }
    }
}
