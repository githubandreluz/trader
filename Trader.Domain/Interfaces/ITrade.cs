using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;

namespace Trader.Domain.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        Sector ClientSector { get; }

        bool IsPublic { get; }
    }
}
