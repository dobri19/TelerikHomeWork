using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenThePackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => repository.Delete(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThePackageIsNotFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => repository.Delete(packageMock.Object));
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void PackageAlreadyExistMessageLogThreeTimes_WhenThePackageWithTheSameVersionIsAddedAlready()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.SetupGet(x => x.Name).Returns("test");
            packageMock.SetupGet(x => x.Version.Major).Returns(1);
            packageMock.SetupGet(x => x.Version.Minor).Returns(1);
            packageMock.SetupGet(x => x.Version.Patch).Returns(1);
            packageMock.SetupGet(x => x.Version.VersionType).Returns(VersionType.alpha);

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            packageMock.Setup(x => x.Equals(packageMock.Object)).Returns(true);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());
            var packageMockAddedToCollectionWithDependency = new Mock<IPackage>();

            packageMockAddedToCollectionWithDependency.Setup(x => x.Dependencies).Returns(new List<IPackage>()
            {
                packageMock.Object
            });

            packageMockAddedToCollectionWithDependency.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(false);

            var collection = new List<IPackage>()
            {
                packageMock.Object,
                packageMockAddedToCollectionWithDependency.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            repository.Delete(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        [TestMethod]
        public void ReturnPackageDeleted_WhenThePackageIsDeletedSuccessfullyFromTheCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.SetupGet(x => x.Name).Returns("test");
            packageMock.SetupGet(x => x.Version.Major).Returns(1);
            packageMock.SetupGet(x => x.Version.Minor).Returns(1);
            packageMock.SetupGet(x => x.Version.Patch).Returns(1);
            packageMock.SetupGet(x => x.Version.VersionType).Returns(VersionType.alpha);

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            packageMock.Setup(x => x.Equals(packageMock.Object)).Returns(true);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            var collection = new List<IPackage>()
            {
                packageMock.Object,
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            var packageRemoved = repository.Delete(packageMock.Object);

            // Assert
            Assert.AreEqual(packageMock.Object, packageRemoved);
        }
    }
}
