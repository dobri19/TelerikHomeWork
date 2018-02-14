using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.CustomExceptions;
using PackageManager.Tests.Repositories.Mocks;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenThePackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => repository.Add(null));
        }

        [TestMethod]
        public void AddAPackageAndCallLogger_WhenThePackageIsNotAlreadyAdded()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void PackageAlreadyExistMessageLogThreeTimes_WhenThePackageWithTheSameVersionIsAddedAlready()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        // The one with derived class
        [TestMethod]
        public void CallUpdateMethod_WhenThePackageAddedAlreadyWithLowerVersion_WithException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepositoryMock(loggerMock.Object, collection);

            // Act & Assert
            Assert.ThrowsException<UpdateMethodCalledException>(() => repository.Add(packageMock.Object));
        }

        // The one with Moq
        [TestMethod]
        public void CallUpdateMethod_WhenThePackageAddedAlreadyWithLowerVersion_WithCallBase()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            // Mocking system under test but using CallBase which will call the base implementation of the methods which are virtual
            // Therefore you should make the Add() method virtual in the PackageRepository class
            var repo = new Mock<PackageRepository>(loggerMock.Object, collection)
            {
                CallBase = true
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            repo.Object.Add(packageMock.Object);

            // Act & Assert
            // After this we are able to mock against the method calls 
            repo.Verify(x => x.Update(packageMock.Object), Times.Once);
        }

        [TestMethod]
        public void PackageWithHigherVersionLogTwice_WhenThePackageAddedAlreadyWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
