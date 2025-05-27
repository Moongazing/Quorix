namespace Moongazing.Quorix.Pipeline.Behaviors.RateLimiting;

public interface IRateLimiterProvider
{
    bool Allow(string key, int maxRequests, TimeSpan window);
}
