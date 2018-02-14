using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallComandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void PerformOperation()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);
            command.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once);
        }
    }
}
