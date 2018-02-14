using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Commands;

namespace PackageManager.Tests.Commands.Mocks
{
    internal class InstallCommandMock : InstallCommand
    {
        public InstallCommandMock(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> MyInstaller
        {
            get
            {
                return this.Installer;
            }
        }

        public IPackage MyPackage
        {
            get
            {
                return this.Package;
            }
        }
    }
}
