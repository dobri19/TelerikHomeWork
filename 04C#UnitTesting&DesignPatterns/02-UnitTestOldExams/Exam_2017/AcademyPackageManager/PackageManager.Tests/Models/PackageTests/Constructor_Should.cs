using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstanceOfPackageClass_WhenValidValuesArePassed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();
            var package = new Package("name", versionMock.Object);

            // Assert
            Assert.IsInstanceOfType(package, typeof(Package));
        }

        [TestMethod]
        public void SetName_WhenIsCorrect()
        {
            // Arrange
            var mockVersion = new Mock<IVersion>();
            var package = new Package("name", mockVersion.Object, null);

            //Act&Assert
            Assert.AreEqual("name", package.Name);
        }

        [TestMethod]
        public void SetVersion_WhenIsCorrect()
        {
            // Arrange
            var mockVersion = new Mock<IVersion>();

            // Act
            var package = new Package("name", mockVersion.Object, null);

            // Assert
            Assert.AreEqual(mockVersion.Object, package.Version);
        }

        [TestMethod]
        public void SetUrl_WhenIsCorrect()
        {
            // Arrange
            var mockVersion = new Mock<IVersion>();

            // Act
            mockVersion.SetupGet(x => x.Major).Returns(1);
            mockVersion.SetupGet(x => x.Minor).Returns(2);
            mockVersion.SetupGet(x => x.Patch).Returns(3);
            mockVersion.SetupGet(x => x.VersionType).Returns(VersionType.final);

            var package = new Package("name", mockVersion.Object, null);

            // Assert
            Assert.AreEqual("1.2.3-final", package.Url);
        }

        [TestMethod]
        public void Set_Should_Throw_WhenNameValueIsUncorrect()
        {
            // Arrange
            var mockVersion = new Mock<IVersion>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Package(null, mockVersion.Object));
        }

        [TestMethod]
        public void Set_Should_Throw_WhenVersionValueIsUncorrect()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Package("name", null));
        }

        [TestMethod]
        public void SetEmptyCollectionOfDependencies_WhenNoArgumentForDependenciesIsPassed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();
            var package = new Package("name", versionMock.Object, null);

            // Assert
            Assert.AreEqual(0, package.Dependencies.Count);
        }

        [TestMethod]
        public void SetCollectionOfDependencies_WhenArgumentForDependenciesIsPassed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();
            var dependencies = new List<IPackage>();
            var package = new Package("name", versionMock.Object, dependencies);

            // Assert
            Assert.AreSame(dependencies, package.Dependencies);
        }
    }
}
