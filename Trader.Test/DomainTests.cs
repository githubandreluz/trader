using Trader.Application.Configuration;
using Trader.Domain.Interfaces;
using Trader.Domain.Models;
using Trader.Domain.Services;

namespace Trader.Test
{
    public class DomainTests
    {
        [Fact(DisplayName = "Value of 2,000,000 with private sector")]
        public void Value_of_2000000_With_Private_Sector()
        {
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var trade = new Trade { Value = 2000000, ClientSector = Sector.Private };

            var tradeCategory = service.GetTradeCategory(new[] { trade });
            Assert.Equal(Risk.HighRisk, tradeCategory.First());
        }
        [Fact(DisplayName = "Value of 400000 with public sector")]
        public void Value_of_400000_With_Public_Sector()
        {
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var trade = new Trade { Value = 400000, ClientSector = Sector.Public };

            var tradeCategory = service.GetTradeCategory(new[] { trade });
            Assert.Equal(Risk.LowRisk, tradeCategory.First());
        }
        [Fact(DisplayName = "Value of 500000 with public sector")]
        public void Value_of_500000_With_Public_Sector()
        {
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var trade = new Trade { Value = 500000, ClientSector = Sector.Public };

            var tradeCategory = service.GetTradeCategory(new[] { trade });
            Assert.Equal(Risk.LowRisk, tradeCategory.First());
        }
        [Fact(DisplayName = "Value of 3000000 with public sector")]
        public void Value_of_3000000_With_Public_Sector()
        {
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var trade = new Trade { Value = 3000000, ClientSector = Sector.Public };

            var tradeCategory = service.GetTradeCategory(new[] { trade });
            Assert.Equal(Risk.MediumRisk, tradeCategory.First());
        }
    }
}