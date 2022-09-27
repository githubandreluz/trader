using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Domain.Interfaces
{
    public interface IConfiguration
    {
        int LimitOfValue { get; }
    }
}
