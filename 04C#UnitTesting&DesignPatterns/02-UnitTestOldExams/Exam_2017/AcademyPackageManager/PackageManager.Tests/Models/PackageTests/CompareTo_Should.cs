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
    public class CompareTo_Should
    {
        [TestMethod]
        public void Throw_WhenOtherValuesIsNull()
        {
            // Assert
            var mockVersion = new Mock<IVersion>();
            var package = new Package("name", mockVersion.Object);
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => package.CompareTo(null));
        }

        [TestMethod]
        public void Throw_WhenNamesAreDifferent()
        {
            // Assert
            var mockVersion = new Mock<IVersion>();
            var package = new Package("name", mockVersion.Object);
            var packageOther = new Package("otherName", mockVersion.Object);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => package.CompareTo(packageOther));
        }

        [TestMethod]
        public void Returns_Zero_When_ThePackagesAreTheSameVersion()
        {
            // Assert
            var mockVersion = new Mock<IVersion>();

            mockVersion.SetupGet(x => x.Major).Returns(10);
            mockVersion.SetupGet(x => x.Minor).Returns(10);
            mockVersion.SetupGet(x => x.Patch).Returns(10);
            mockVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var package = new Package("name", mockVersion.Object);

            var mockVersionOther = new Mock<IVersion>();

            mockVersionOther.SetupGet(x => x.Major).Returns(10);
            mockVersionOther.SetupGet(x => x.Minor).Returns(10);
            mockVersionOther.SetupGet(x => x.Patch).Returns(10);
            mockVersionOther.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageOther = new Package("name", mockVersionOther.Object);

            // Act
            var result = package.CompareTo(packageOther);

            // Act & Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(2, 2, 2, VersionType.alpha)]
        [DataRow(1, 1, 1, VersionType.beta)]
        [DataRow(1, 2, 1, VersionType.alpha)]
        [DataRow(2, 1, 1, VersionType.alpha)]
        [DataRow(2, 2, 2, VersionType.beta)]
        public void Return_One_When_ThePackagePassedIsOlderVersion(int major, int minor, int patch, VersionType versionType)
        {
            // Assert
            var mockVersion = new Mock<IVersion>();

            mockVersion.SetupGet(x => x.Major).Returns(major);
            mockVersion.SetupGet(x => x.Minor).Returns(minor);
            mockVersion.SetupGet(x => x.Patch).Returns(patch);
            mockVersion.SetupGet(x => x.VersionType).Returns(versionType);

            var package = new Package("name", mockVersion.Object);

            var mockVersionOther = new Mock<IVersion>();

            mockVersionOther.SetupGet(x => x.Major).Returns(1);
            mockVersionOther.SetupGet(x => x.Minor).Returns(1);
            mockVersionOther.SetupGet(x => x.Patch).Returns(1);
            mockVersionOther.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageOther = new Package("name", mockVersionOther.Object);

            // Act
            var result = package.CompareTo(packageOther);

            // Act & Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [DataRow(2, 2, 2, VersionType.alpha)]
        [DataRow(1, 1, 1, VersionType.beta)]
        [DataRow(1, 2, 1, VersionType.alpha)]
        [DataRow(2, 1, 1, VersionType.alpha)]
        [DataRow(2, 2, 2, VersionType.beta)]
        public void Return_MinusOne_When_ThePackagePassedIsNewerVersion(int major, int minor, int patch, VersionType versionType)
        {
            // Assert
            var mockVersion = new Mock<IVersion>();

            mockVersion.SetupGet(x => x.Major).Returns(1);
            mockVersion.SetupGet(x => x.Minor).Returns(1);
            mockVersion.SetupGet(x => x.Patch).Returns(1);
            mockVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var package = new Package("name", mockVersion.Object);

            var mockVersionOther = new Mock<IVersion>();

            mockVersionOther.SetupGet(x => x.Major).Returns(major);
            mockVersionOther.SetupGet(x => x.Minor).Returns(minor);
            mockVersionOther.SetupGet(x => x.Patch).Returns(patch);
            mockVersionOther.SetupGet(x => x.VersionType).Returns(versionType);

            var packageOther = new Package("name", mockVersionOther.Object);

            // Act
            var result = package.CompareTo(packageOther);

            // Act & Assert
            Assert.AreEqual(-1, result);
        }

        //[TestMethod]
        //public void Calculate_ThisFersionFinalValid()
        //{
        //    // Assert
        //    var mockVersion = new Mock<IVersion>();

        //    mockVersion.SetupGet(x => x.Major).Returns(10);
        //    mockVersion.SetupGet(x => x.Minor).Returns(10);
        //    mockVersion.SetupGet(x => x.Patch).Returns(10);
        //    mockVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

        //    var package = new Package("name", mockVersion.Object);

        //    var mockVersionOther = new Mock<IVersion>();

        //    mockVersionOther.SetupGet(x => x.Major).Returns(10);
        //    mockVersionOther.SetupGet(x => x.Minor).Returns(10);
        //    mockVersionOther.SetupGet(x => x.Patch).Returns(10);
        //    mockVersionOther.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

        //    //var packageOther = new Package("name", mockVersionOther.Object);
        //    var packageOther = new Package("name", mockVersionOther.Object);

        //    // Act
        //    var result = package.CalculateVersion(10, 10, 10, VersionType.alpha);

        //    // Act & Assert
        //    Assert.AreEqual(11100, result);
        //}
    }
}
