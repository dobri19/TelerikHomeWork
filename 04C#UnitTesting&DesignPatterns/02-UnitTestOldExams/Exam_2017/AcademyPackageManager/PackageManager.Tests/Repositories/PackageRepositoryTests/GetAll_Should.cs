using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestClass]
    public class GetAll_Should
    {
        [TestMethod]
        public void ReturnsEmptyCollection_WhenTheCollectionIsNotPassed()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var coll = new List<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act
            var packagesFound = repository.GetAll();

            // Assert
            Assert.AreEqual(0, packagesFound.Count());
        }

        [TestMethod]
        public void ReturnsCollectionWithNumberOfElementsPassed_WhenTheCollectionPassedIsNotEmpty()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var coll = new List<IPackage>(new List<IPackage>()
            {
                packageMock.Object
            });

            var repository = new PackageRepository(loggerMock.Object, coll);

            // Act
            var packagesFound = repository.GetAll();

            // Assert
            Assert.AreEqual(1, packagesFound.Count());
        }
    }
}
