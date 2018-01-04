using Cosmetics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    public interface ICream
    {
        ScentType Scent { get; }
    }
}
