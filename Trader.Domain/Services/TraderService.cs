using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Interfaces;
using Trader.Domain.Models;

namespace Trader.Domain.Services
{
    public class TraderService : ITraderService
    {
        private readonly IConfiguration _config;
        public TraderService(IConfiguration config)
        {
            _config = config;
        }
        #region private_methods
        private IEnumerable<Type> getAllRulers(Type MyType)
        {
            return Assembly.GetAssembly(MyType)
                    .GetTypes()
                    .Where(TheType =>
                        TheType.IsClass
                        && !TheType.IsAbstract
                        && TheType.IsSubclassOf(MyType)
                    );
        }
        private Risk DefineCategory(ITrade trade)
        {
            var rulers = getAllRulers(typeof(Rules<ITrade>));

            foreach (var ruler in rulers)
            {
                var obj = (Rules<ITrade>)Activator.CreateInstance(ruler);
                obj.addAllRules(trade, _config.LimitOfValue);
                var risk = obj.GetRisk(trade);
                if (risk != null)
                    return risk.Value;
            }

            throw new InvalidOperationException($"There is no risk definition for value '{trade.Value}' and '{trade.ClientSector} Sector'");
        }
        #endregion

        #region public_methods
        public IEnumerable<Risk> GetTradeCategory(IEnumerable<ITrade> portifolio) => portifolio.Select(x => DefineCategory(x));
        #endregion
    }
}
