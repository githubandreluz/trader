using Trader.IoC;
using TraderService;

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json");
var configuration = configurationBuilder.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        Bootstrap.RegisterServices(services);
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();
