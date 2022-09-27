
using Trader.Domain.Models;
using Business = Trader.Domain.Interfaces;

namespace Trader.Application.Interfaces
{
    public interface ITradeAdapter
    {
        IEnumerable<Business.ITrade> AppToDomain(IEnumerable<ITrade> portifolio);
        IEnumerable<string> DomainToApp(IEnumerable<Risk> riskCategories);
    }
}
