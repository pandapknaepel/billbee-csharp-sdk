using System.Collections.Concurrent;

namespace Panda.NuGet.BillbeeClient.Utilities;

public interface IRateLimiter
{
    Task ThrottleAsync();
}

public class RateLimiter : IRateLimiter
{
    private readonly SemaphoreSlim _rateLimiter = new(6);
    private readonly ConcurrentQueue<DateTimeOffset> _requestTimestamps = new();

    public async Task ThrottleAsync()
    {
        await _rateLimiter.WaitAsync();

        while (_requestTimestamps.TryPeek(out var oldestTimestamp))
        {
            if (DateTimeOffset.UtcNow - oldestTimestamp > TimeSpan.FromMinutes(1))
            {
                _requestTimestamps.TryDequeue(out _);
                _rateLimiter.Release();
            }
            else
            {
                break;
            }
        }

        _requestTimestamps.Enqueue(DateTimeOffset.UtcNow);
    }
}