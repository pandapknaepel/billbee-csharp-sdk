using System.Collections.Concurrent;

namespace Panda.NuGet.BillbeeClient.Utilities;

public interface IRateLimiter
{
    Task ThrottleAsync(object key, int maxRequestsPerTimeRange = 6, int timeRangeInSeconds = 60);
}

public class RateLimiter : IRateLimiter
{
    private readonly ConcurrentDictionary<object, SemaphoreSlim> _rateLimiters = new();
    private readonly ConcurrentDictionary<object, ConcurrentQueue<DateTimeOffset>> _requestTimestamps = new();

    public async Task ThrottleAsync(object key, int maxRequestsPerTimeRange = 6, int timeRangeInSeconds = 60)
    {
        var rateLimiter = _rateLimiters.GetOrAdd(key, new SemaphoreSlim(maxRequestsPerTimeRange));
        var requestTimestamps = _requestTimestamps.GetOrAdd(key, new ConcurrentQueue<DateTimeOffset>());

        await rateLimiter.WaitAsync();

        while (requestTimestamps.TryPeek(out var oldestTimestamp))
        {
            if ((DateTimeOffset.UtcNow - oldestTimestamp).TotalSeconds > timeRangeInSeconds)
            {
                requestTimestamps.TryDequeue(out _);
                rateLimiter.Release();
            }
            else
            {
                break;
            }
        }

        requestTimestamps.Enqueue(DateTimeOffset.UtcNow);
    }
}