using System.Collections.Concurrent;

namespace ConsumerQueueExample.Services;

public class AsynchronousQueue<T>
{
    private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
        _semaphore.Release();
    }

    public async Task<T> DequeueAsync(CancellationToken cancellationToken)
    {
        await _semaphore.WaitAsync(cancellationToken);
        _queue.TryDequeue(out var item);
        return item;
    }
}