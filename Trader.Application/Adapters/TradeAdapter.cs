using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Application.Interfaces;
using Trader.Domain.Models;
using App = Trader.Application.Interfaces;
using Business = Trader.Domain.Interfaces;


namespace Trader.Application.Adapters
{
    public class TradeAdapter : ITradeAdapter
    {
        private Sector ParseSector(string clientSector) =>
            Enum.TryParse(clientSector, true, out Sector s) ? s : throw new ArgumentException("Invalid Client Sector", nameof(clientSector));
        public IEnumerable<Business.ITrade> AppToDomain(IEnumerable<App.ITrade> portifolio) =>
            portifolio.Select(x =>
                new Trade
                {
                    Value = x.Value,
                    ClientSector = ParseSector(x.ClientSector)
                });
        public IEnumerable<string> DomainToApp(IEnumerable<Risk> riskCategories) =>
            riskCategories.Select(x => x.ToString().ToUpper());
    }
}
