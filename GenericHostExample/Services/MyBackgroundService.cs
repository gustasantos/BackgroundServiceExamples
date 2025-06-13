using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyProjectBackgroundService.Services;

public class MyBackgroundService(ILogger<MyBackgroundService> logger, IOptions<Configurations> options)
    : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger = logger;
    private readonly Configurations _config = options.Value;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Service is starting.");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("execution service: {Time}", DateTimeOffset.Now);
            await Task.Delay(_config.Intervalo, stoppingToken);
        }
        
        _logger.LogInformation("Service is stopping.");
    }
}

