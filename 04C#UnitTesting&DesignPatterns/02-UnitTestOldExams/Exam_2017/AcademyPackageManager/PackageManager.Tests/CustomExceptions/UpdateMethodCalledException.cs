using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.CustomExceptions
{
    public class UpdateMethodCalledException : Exception
    {
        public UpdateMethodCalledException(string msg)
            : base(msg)
        {
        }
    }
}
