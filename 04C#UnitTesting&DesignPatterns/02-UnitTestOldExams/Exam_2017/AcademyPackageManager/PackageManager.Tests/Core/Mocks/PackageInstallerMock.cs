using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.Mocks
{
    internal class PackageInstallerMock : PackageInstaller
    {
        public PackageInstallerMock(IDownloader downloader, IProject project)
            : base(downloader, project)
        {
        }

        public int Counter { get; private set; }

        public override void PerformOperation(IPackage package)
        {
            this.Counter++;
        }
    }
}
