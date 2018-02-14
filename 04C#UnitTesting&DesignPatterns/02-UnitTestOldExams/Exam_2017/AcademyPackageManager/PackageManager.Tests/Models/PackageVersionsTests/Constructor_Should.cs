using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersionsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetMajor_WhenValueIsValid()
        {
            // Arrange & Act
            var packageVersion = new PackageVersion(1, 5, 6, Enums.VersionType.alpha);
            var versionMajor = packageVersion.Major;
            // Assert
            Assert.AreEqual(1, versionMajor);
        }

        [TestMethod]
        public void SetMinor_WhenValueIsValid()
        {
            // Arrange & Act
            var packageVersion = new PackageVersion(2, 3, 4, Enums.VersionType.beta);
            var versionMinor = packageVersion.Minor;
            // Assert
            Assert.AreEqual(3, versionMinor);
        }

        [TestMethod]
        public void SetPatch_WhenValueIsValid()
        {
            // Arrange & Act
            var packageVersion = new PackageVersion(4, 6, 11, Enums.VersionType.beta);
            var versionPatch = packageVersion.Patch;
            // Assert
            Assert.AreEqual(11, versionPatch);
        }

        [TestMethod]
        public void SetType_WhenValueIsValid()
        {
            // Arrange & Act
            var packageVersion = new PackageVersion(4, 6, 11, Enums.VersionType.beta);
            var versionType = packageVersion.VersionType;
            // Assert
            Assert.AreEqual(VersionType.beta, versionType);
        }

        [TestMethod]
        public void Set_Should_Throw_WhenMajorValueIsNegative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(-4, 6, 11, VersionType.beta));
        }

        [TestMethod]
        public void Set_Should_Throw_WhenMinorValueIsNegative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(4, -6, 11, VersionType.beta));
        }

        [TestMethod]
        public void Set_Should_Throw_WhenPatchValueIsNegative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(4, 6, -11, VersionType.beta));
        }

        [TestMethod]
        public void Set_Should_Throw_WhenTypeValueIsNotValid()
        {
            // Arrange
            var wrongType = (VersionType)122;
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(4, 6, 11, wrongType));
        }

        [TestMethod]
        public void ReturnAnInstanceOfThePackageVersionCalss_WhenTheValuesAreValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.IsInstanceOfType(version, typeof(PackageVersion));
        }
    }
}
