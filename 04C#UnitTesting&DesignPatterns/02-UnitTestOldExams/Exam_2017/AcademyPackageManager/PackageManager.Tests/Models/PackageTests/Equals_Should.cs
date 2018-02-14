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
    public class Equals_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenTheObjectPassedIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => package.Equals(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenTheObjectPassedIsNotIPackage()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => package.Equals("not package"));
        }

        [TestMethod]
        public void ReturnTrue_WhenThePackagesAreEqual()
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package("test", versionMockPackageOne.Object);

            versionMockPackageOne.SetupGet(x => x.Major).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageOne.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var versionMockPackageTwo = new Mock<IVersion>();

            versionMockPackageTwo.SetupGet(x => x.Major).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageTwo = new Package("test", versionMockPackageTwo.Object);

            // Act
            var result = packageOne.Equals(packageTwo);

            // Assert
            Assert.IsTrue(result);
        }

        [DataRow("not test", 1, 1, 1, VersionType.alpha)]
        [DataRow("test", 2, 1, 1, VersionType.alpha)]
        [DataRow("test", 1, 2, 1, VersionType.alpha)]
        [DataRow("test", 1, 1, 2, VersionType.alpha)]
        [DataRow("test", 1, 1, 1, VersionType.beta)]
        public void ReturnFalse_WhenThePackagesAreNotEqual(string name, int major, int minor, int patch, VersionType versionType)
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package(name, versionMockPackageOne.Object);

            versionMockPackageOne.SetupGet(x => x.Major).Returns(major);
            versionMockPackageOne.SetupGet(x => x.Minor).Returns(minor);
            versionMockPackageOne.SetupGet(x => x.Patch).Returns(patch);
            versionMockPackageOne.SetupGet(x => x.VersionType).Returns(versionType);

            var versionMockPackageTwo = new Mock<IVersion>();

            versionMockPackageTwo.SetupGet(x => x.Major).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageTwo = new Package("test", versionMockPackageTwo.Object);

            // Act
            var result = packageOne.Equals(packageTwo);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_Check()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);
            var packageOther = package;
            var packageThree = new Package("test", versionMock.Object);
            // Act & Assert
            Assert.AreEqual(package.GetHashCode(), packageOther.GetHashCode());
            Assert.AreNotEqual(package.GetHashCode(), packageThree.GetHashCode());
            Assert.IsInstanceOfType(package.GetHashCode(), typeof(int));
        }
    }
}
