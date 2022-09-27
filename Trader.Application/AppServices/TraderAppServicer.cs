using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App = Trader.Application.Interfaces;
using Business = Trader.Domain.Interfaces;

namespace Trader.Application.AppServices
{
    public class TraderAppServicer : App.ITraderAppService
    {
        private readonly Business.ITraderService _traderService;
        private readonly App.ITradeAdapter _tradeAdapter;
        public TraderAppServicer(Business.ITraderService traderService, App.ITradeAdapter tradeAdapter)
        {
            _traderService = traderService;
            _tradeAdapter = tradeAdapter;
        }
        public IEnumerable<string> GetTradeCategory(IEnumerable<App.ITrade> portifolio) => 
            _tradeAdapter.DomainToApp(_traderService.GetTradeCategory(_tradeAdapter.AppToDomain(portifolio)));

    }
}

