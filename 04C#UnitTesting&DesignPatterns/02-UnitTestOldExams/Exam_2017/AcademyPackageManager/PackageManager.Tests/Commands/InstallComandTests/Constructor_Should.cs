using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Tests.Commands.Mocks;

namespace PackageManager.Tests.Commands.InstallComandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstanceOfInstallCommandClass_WhenThePassedValuesAreValid()
        {
            // Arrange & Act
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var command = new InstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.IsInstanceOfType(command, typeof(InstallCommand));
        }

        [TestMethod]
        public void Set_Installer_WhenConstructingObject()
        {
            // Assert
            var package = new Mock<IPackage>();
            var installer = new Mock<IInstaller<IPackage>>();

            // Act
            var command = new InstallCommandMock(installer.Object, package.Object);

            // Assert
            Assert.AreSame(installer.Object, command.MyInstaller);
        }

        [TestMethod]
        public void SetPackage_WhenConstructingTheObject()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, command.MyPackage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThePassedInstallerIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThePassedPackageIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));
        }

        [TestMethod]
        public void SetOperationTypeToInstall_WhenConstructingTheObject()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreEqual(InstallerOperation.Install, installerMock.Object.Operation);
        }
    }
}
