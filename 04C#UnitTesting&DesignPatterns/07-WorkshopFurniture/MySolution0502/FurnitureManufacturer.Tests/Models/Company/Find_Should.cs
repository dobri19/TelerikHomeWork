using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FurnitureManufacturer.Models.Contracts;

namespace FurnitureManufacturer.Tests.Models.Company
{
    [TestClass]
    public class Find_Should
    {

        [TestMethod]
        public void ThrowArgumentNullException_WhenPassedNullParam()
        {
            var validName = "Karamba";
            var validRegistrationNumber = "4564567899";
            var sut = new FurnitureManufacturer.Models.Company(validName, validRegistrationNumber);

            Assert.ThrowsException<ArgumentNullException>(() => sut.Find(null));
        }

        [TestMethod]
        public void AddFurnitureToLocalCollection_WhenPassedValidParam()
        {
            var validName = "Pesho";
            var validRegistrationNumber = "1234567890";

            var validModel = "Patka";
            var furnitureStub = new Mock<IFurniture>();
            furnitureStub.SetupGet(x => x.Model).Returns(validModel);

            var sut = new FurnitureManufacturer.Models.Company(validName, validRegistrationNumber);
            sut.Furnitures.Clear();
            sut.Furnitures.Add(furnitureStub.Object);

            var result = sut.Find(validModel);

            Assert.AreSame(furnitureStub.Object, result);
        }
    }
}
