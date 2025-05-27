namespace Moongazing.Quorix.Pipeline.Behaviors.RateLimiting;

public class InMemoryRateLimiterProvider : IRateLimiterProvider
{
    private readonly Dictionary<string, Queue<DateTime>> _requestLogs = new();
    private readonly object @lock = new();

    public bool Allow(string key, int maxRequests, TimeSpan window)
    {
        lock (@lock)
        {
            var now = DateTime.UtcNow;
            if (!_requestLogs.TryGetValue(key, out var timestamps))
            {
                timestamps = new Queue<DateTime>();
                _requestLogs[key] = timestamps;
            }

            while (timestamps.Count > 0 && now - timestamps.Peek() > window)
                timestamps.Dequeue();

            if (timestamps.Count >= maxRequests)
                return false;

            timestamps.Enqueue(now);
            return true;
        }
    }
}
