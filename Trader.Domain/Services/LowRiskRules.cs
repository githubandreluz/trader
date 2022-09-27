using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Interfaces;
using Trader.Domain.Models;

namespace Trader.Domain.Services
{
    public class LowRiskRules : Rules<ITrade>
    {
        private void isPublicAndLessThen(ITrade trade, int limitOfValue) =>
            Add(x => trade.Value < limitOfValue && trade.IsPublic);

        public override void addAllRules(ITrade trade, int limitOfValue)
        {
            isPublicAndLessThen(trade, limitOfValue);
        }
        public override Risk? GetRisk(ITrade trade) =>
            ComputeRules(trade) ? Risk.LowRisk : null;




    }
}
