using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
                    AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    public class AtttributeVersion : Attribute
    {
        public AtttributeVersion(string version)
        {
            this.Version = version;
        }

        public string Version { get; set; }

        public override string ToString()
        {
            return this.Version;
        }
    }
}
