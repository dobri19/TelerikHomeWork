using FurnitureManufacturer.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace FurnitureManufacturer.Tests.Models.Company
{
    [TestClass]
    public class Catalog_Should
    {
        [TestMethod]
        public void ReturnValidMessage_WhenCompanyHasNoFurniture()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";
            var sut = new FurnitureManufacturer.Models.Company(validName, validRegistrationNumber);

            var result = sut.Catalog();

            Assert.AreEqual($"{validName} - {validRegistrationNumber} - no furnitures", result);
        }

        [TestMethod]
        public void ReturnValidMessage_WhenCompanyHasOneFurniture()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";

            var validModel = "Patka";
            var furnitureStub = new Mock<IFurniture>();
            furnitureStub.SetupGet(x => x.Model).Returns(validModel);

            var sut = new FurnitureManufacturer.Models.Company(validName, validRegistrationNumber);
            sut.Furnitures.Clear();
            sut.Furnitures.Add(furnitureStub.Object);

            var result = sut.Catalog();

            var expectedLine1 = $"{validName} - {validRegistrationNumber} - 1 furniture";

            Assert.IsTrue(result.Contains(expectedLine1)); // Why are we checking only line 1?
        }

        // What else can be tested?

        [TestMethod]
        public void ReturnValidMessage_WhenCompanyHasTwoFurnitures()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";

            var validModel = "Patka";
            var furnitureStub = new Mock<IFurniture>();
            furnitureStub.SetupGet(x => x.Model).Returns(validModel);

            var validModel2 = "Vatka";
            var furnitureStub2 = new Mock<IFurniture>();
            furnitureStub2.SetupGet(x => x.Model).Returns(validModel2);

            var sut = new FurnitureManufacturer.Models.Company(validName, validRegistrationNumber);
            sut.Furnitures.Clear();
            sut.Furnitures.Add(furnitureStub.Object);
            sut.Furnitures.Add(furnitureStub2.Object);

            var result = sut.Catalog();

            var expectedLine1 = $"{validName} - {validRegistrationNumber} - 2 furnitures";

            Assert.IsTrue(result.Contains(expectedLine1));
        }
    }
}
