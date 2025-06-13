using ConsumerQueueExample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(typeof(AsynchronousQueue<>));
        
        //Registro da fila
        services.AddHostedService<ConsumerQueueService>();
    })
    .Build();
    
var fila = host.Services.GetRequiredService<AsynchronousQueue<string>>();
fila.Enqueue("message 1");
fila.Enqueue("message 2");
fila.Enqueue("message 3");

await host.RunAsync();
    