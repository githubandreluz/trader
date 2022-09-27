using System.Text.Json;
using Trader;
using Trader.Application.Interfaces;
using Trader.Application.Model;

namespace TraderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITraderAppService _traderAppService;
        public Worker(ILogger<Worker> logger, ITraderAppService traderAppService)
        {
            _logger = logger;
            _traderAppService = traderAppService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputFile_Portifolio.json");
            var inputFile = JSONParser.Deserialize<List<Trade>>(File.ReadAllText(path));

            Console.WriteLine("************************************************");
            Console.WriteLine("INPUT (TRADES): ");
            Console.WriteLine("************************************************");
            Console.WriteLine(JSONParser.Serialize(inputFile));

            var tradesCategory = _traderAppService.GetTradeCategory(inputFile);

            Console.WriteLine("************************************************");
            Console.WriteLine("OUTPUT (TRADES CATEGORY): ");
            Console.WriteLine("************************************************");
            Console.WriteLine("tradeCategories = " + JSONParser.Serialize(tradesCategory));


            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}