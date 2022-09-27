using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Interfaces;
using Trader.Domain.Models;

namespace Trader.Domain.Services
{
    public abstract class Rules<T>
        where T : ITrade
    {
        public Rules()
        {
            expressions = new List<Expression<Func<ITrade, bool>>>();
        }
        private List<Expression<Func<ITrade, bool>>> expressions { get; set; }

        public bool ComputeRules(ITrade trade) =>
            !expressions.Any(x => x.Compile()(trade) == false);
        public void Add(Expression<Func<ITrade, bool>> exp)
        {
            expressions.Add(exp);
        }

        public abstract void addAllRules(ITrade trade, int limitOfValue);
        public abstract Risk? GetRisk(ITrade trade);
    }
}
