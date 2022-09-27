using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Application.Interfaces
{
    public interface ITraderAppService
    {
        IEnumerable<string> GetTradeCategory(IEnumerable<ITrade> portifolio);
    }
}
