using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business = Trader.Domain.Interfaces;

namespace Trader.Configuration
{
    public class Configuration : Business.IConfiguration
    {
        public int LimitOfValue => 1000000;
    }
}
