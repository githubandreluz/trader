using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader;
using Trader.Application.AppServices;
using Trader.Application.Interfaces;
using Trader.Application.Model;

namespace Trader.Test
{
    public class IntegrationTests
    {
        [Fact(DisplayName = "Integration Test - Value of 2,000,000 with private sector")]
        public void Integration_Test_Value_of_2000000_With_Private_Sector()
        {
            var inputJson = "[{\"Value\": 2000000,\"ClientSector\": \"Private\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);

            var tradesCategories = appService.GetTradeCategory(portifolio);
            var result = JSONParser.Serialize(tradesCategories);
            Assert.Equal("[\r\n  \"HIGHRISK\"\r\n]", result);
        }
        [Fact(DisplayName = "Integration Test - Value of 400000 with private sector")]
        public void Integration_Test_Value_of_400000_With_Private_Sector()
        {
            var inputJson = "[{\"Value\": 400000,\"ClientSector\": \"Public\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);

            var tradesCategories = appService.GetTradeCategory(portifolio);
            var result = JSONParser.Serialize(tradesCategories);
            Assert.Equal("[\r\n  \"LOWRISK\"\r\n]", result);
        }
        [Fact(DisplayName = "Integration Test - Value of 500000 with private sector")]
        public void Integration_Test_Value_of_500000_With_Private_Sector()
        {
            var inputJson = "[{\"Value\": 500000,\"ClientSector\": \"Public\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);

            var tradesCategories = appService.GetTradeCategory(portifolio);
            var result = JSONParser.Serialize(tradesCategories);
            Assert.Equal("[\r\n  \"LOWRISK\"\r\n]", result);
        }
        [Fact(DisplayName = "Integration Test - Value of 3000000 with private sector")]
        public void Integration_Test_Value_of_3000000_With_Private_Sector()
        {
            var inputJson = "[{\"Value\": 3000000,\"ClientSector\": \"Public\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);

            var tradesCategories = appService.GetTradeCategory(portifolio);
            var result = JSONParser.Serialize(tradesCategories);
            Assert.Equal("[\r\n  \"MEDIUMRISK\"\r\n]", result);
        }
        [Fact(DisplayName = "Integration Test - Throw Risk not defined")]
        public void Integration_Test_ThrowRiskNotDeFined()
        {
            var inputJson = "[{\"Value\": 1000000,\"ClientSector\": \"Public\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);
            var tradesCategories = appService.GetTradeCategory(portifolio);
            var ex = Assert.Throws<InvalidOperationException>(() => JSONParser.Serialize(tradesCategories));
            Assert.IsType<InvalidOperationException>(ex);
        }
        [Fact(DisplayName = "Integration Test - Throw Invalid Sector")]
        public void Integration_Test_ThrowInvalidSector()
        {
            var inputJson = "[{\"Value\": 1000000,\"ClientSector\": \"External\"}]";
            var portifolio = JSONParser.Deserialize<IEnumerable<Trade>>(inputJson);
            var config = new Application.Configuration.Configuration();
            var service = new Domain.Services.TraderService(config);
            var adapter = new Application.Adapters.TradeAdapter();
            var appService = new TraderAppServicer(service, adapter);
            var tradesCategories = appService.GetTradeCategory(portifolio);
            var ex = Assert.Throws<ArgumentException>(() => JSONParser.Serialize(tradesCategories));
            Assert.Equal("clientSector", ex.ParamName);
        }
    }
}
