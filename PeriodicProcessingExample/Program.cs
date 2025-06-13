using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeriodicProcessingExample.Services;

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
        services.AddHostedService<PeriodicProcessingService>();

        //Adiciona configurações ao contêiner de DI
        services.Configure<ProcessingSettings>
            (hostContext.Configuration.GetSection("Configurations"));
    })
    .Build();
    
await host.RunAsync();

public class ProcessingSettings
{
    public int Interval { get; set; }
}