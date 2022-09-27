using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Interfaces;

namespace Trader.Domain.Models
{
    public class Trade : ITrade
    {
        public double Value { get; set; }

        public Sector ClientSector { get; set; }

        public bool IsPublic => ClientSector == Sector.Public;
    }
}
