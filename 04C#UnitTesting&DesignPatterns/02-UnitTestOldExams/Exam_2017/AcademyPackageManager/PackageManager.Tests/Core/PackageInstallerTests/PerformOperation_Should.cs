using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestClass]
    public class PerformOperation_Should
    {
        [TestMethod]
        public void InstallPackageWithoutDependencies_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Once);
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void InstallPackageWithDependenciesCountEqualsOne_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var packageDependencyMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            packageDependencyMock.SetupGet(x => x.Dependencies).Returns(new List<IPackage>());

            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>()
            {
                packageDependencyMock.Object
            });

            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Exactly(2));
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
