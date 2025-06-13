using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PeriodicProcessingExample.Services;

public class PeriodicProcessingService(ILogger<PeriodicProcessingService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("PeriodicProcessingService is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                logger.LogInformation("Starting processing on: {time}", DateTimeOffset.Now);
                ProcessData();
                logger.LogInformation("Ending processing on: {time}", DateTimeOffset.Now);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error during processing.");
            }
            
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
        
        logger.LogInformation("periodic processing service completed on: {time}", DateTimeOffset.Now);
    }

    private void ProcessData()
    {
        logger.LogInformation("Processing data.");
        Thread.Sleep(TimeSpan.FromMinutes(1)); //Simulando tempo de processamento
    }
}