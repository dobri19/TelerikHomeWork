using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FurnitureManufacturer.Models.Contracts;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Furnitures;

namespace FurnitureManufacturer.Tests.Models.Company
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        public void ThrowNullException_WhenFurnitureIsNull()
        {
            // Arrange
            ICompany company = new FurnitureManufacturer.Models.Company("Voltera", "3453434562");

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => company.Add(null));
        }

        [TestMethod]
        public void AddFurniture_WhenFurnitureIsCorrect()
        {
            // Arrange
            ICompany company = new FurnitureManufacturer.Models.Company("Voltera", "3453434562");

            // Act
            var furnitureStub = new Mock<IFurniture>();
            company.Add(furnitureStub.Object);

            // Assert
            Assert.AreEqual(1, company.Furnitures.Count);
            Assert.IsTrue(company.Furnitures.Contains(furnitureStub.Object));
        }

        [TestMethod]
        public void AddFurnitureOnce_WhenFurnitureIsAdded()
        {
            // Arrange
            var company = new Mock<ICompany>();
            var furniture = new Mock<IFurniture>();

            // Act 
            company.Object.Add(furniture.Object);

            // Assert
            company.Verify(x => x.Add(furniture.Object), Times.Once);
        }
    }
}
