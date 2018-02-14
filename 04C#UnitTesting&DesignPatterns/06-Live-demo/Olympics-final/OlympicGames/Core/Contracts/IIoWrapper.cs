using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Core.Contracts
{
    public interface IIoWrapper
    {
        void WriteWithWrapper(string msg);

        string ReadWithWrapper();
    }
}
