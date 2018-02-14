using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageManager.Info;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetName_WhenValueIsValid()
        {
            // Arrange & Act
            var project = new Project("again", "country");
            var projectName = project.Name;
            // Assert
            Assert.AreEqual("again", projectName);
        }

        [TestMethod]
        public void SetLocation_WhenValueIsValid()
        {
            // Arrange & Act
            var project = new Project("again", "country");
            var projectLocation = project.Location;
            // Assert
            Assert.AreEqual("country", projectLocation);
        }

        [TestMethod]
        public void Set_Should_Throw_WhenNameIsUnvalid()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Project(null, "city"));
        }

        [TestMethod]
        public void Set_Should_Throw_WhenLocationIsUnvalid()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Project("name", null));
        }

        [TestMethod]
        public void SetTheRepository_WhenTheParameterIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<IPackage>>();

            var project = new Project("again", "country", repositoryMock.Object);
            // Arrange & Act & Assert
            Assert.AreSame(repositoryMock.Object, project.PackageRepository);
        }

        [TestMethod]
        public void Set_Should_CreateNewRepository_WhenPackagesAreNull()
        {
            var project = new Project("again", "country", null);
            var repo = new PackageRepository(new ConsoleLogger());
            // Arrange & Act & Assert
            Assert.IsInstanceOfType(repo, typeof(IRepository<IPackage>));
        }

        [TestMethod]
        public void ReturnInstanceOfTheProjectClass_WhenTheValuesPassedAreValid()
        {
            // Arrange & Act
            var project = new Project("name", "location");

            // Assert
            Assert.IsInstanceOfType(project, typeof(Project));
        }
    }
}
