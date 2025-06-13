using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyProjectBackgroundService.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        //Carrega configurações do appsettings.json
        config.AddJsonFile("appsettings.json",
            optional: false,
            reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        //Registra o Background Service
        services.AddHostedService<MyBackgroundService>();

        //Adiciona configurações ao contêiner de DI
        services.Configure<Configurations>
            (hostContext.Configuration.GetSection("Configurations"));
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build();
    
await host.RunAsync();

public class Configurations 
{
    public int Intervalo { get; set; }
}