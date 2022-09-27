using Microsoft.Extensions.DependencyInjection;
using Trader.Application.Adapters;
using Trader.Application.AppServices;
using Trader.Application.Configuration;
using Trader.Application.Interfaces;
using Trader.Domain.Interfaces;
using Trader.Domain.Models;
using Trader.Domain.Services;

namespace Trader.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ITraderService), typeof(TraderService));
            services.AddSingleton(typeof(ITradeAdapter), typeof(TradeAdapter));
            services.AddSingleton(typeof(ITraderAppService), typeof(TraderAppServicer));
            services.AddSingleton(typeof(IConfiguration), typeof(Configuration));

        }
    }
}