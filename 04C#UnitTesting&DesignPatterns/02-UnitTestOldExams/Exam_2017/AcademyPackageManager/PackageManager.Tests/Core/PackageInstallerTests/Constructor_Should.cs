using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Core.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void RestorePackges_WhenObjectIsConstructed()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object,
                packageMock.Object
            });

            // Act
            var installer = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);

            // Assert
            Assert.AreEqual(3, installer.Counter);
        }

        [TestMethod]
        public void RestorePackges_WhenObjectIsConstructed_Moq()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object
            });

            // Mocking the SUT but with behaviour CallBase = true
            var installer = new Mock<PackageInstaller>(downloaderMock.Object, projectMock.Object)
            {
                CallBase = true
            };

            installer.Setup(x => x.PerformOperation(It.IsAny<IPackage>()));

            // Act
            var installerObject = installer.Object;

            // Assert
            installer.Verify(x => x.PerformOperation(It.IsAny<IPackage>()), Times.Exactly(2));
        }
    }
}
