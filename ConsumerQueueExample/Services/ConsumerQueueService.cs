using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsumerQueueExample.Services;

public class ConsumerQueueService(ILogger<ConsumerQueueService> logger, AsynchronousQueue<string> queue) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Consumer Queue Service is running.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var message = await queue.DequeueAsync(stoppingToken);
                ProcessMessage(message);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Consumer Queue Service failed.");
            }
        }
        logger.LogInformation("Consumer Queue Service is stopping.");
    }

    private void ProcessMessage(string message)
    {
        logger.LogInformation($"Consumer Queue Service received message: {message}");
    }
}