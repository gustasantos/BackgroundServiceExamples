using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedServiceExample.Services;

public class MyBackgroundService(ILogger<MyBackgroundService> logger) : IHostedService, IDisposable
{
    private Timer? _timer;
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Service is starting.");
        
        //Configura um Timer para executar uma tarefa periódica
        _timer = new Timer(RunTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Service is stopping.");
        
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private void RunTask(object? state)
    {
        logger.LogInformation("Service is running.");
    }
}