namespace Moongazing.Quorix.Pipeline.Behaviors.Caching;

/// <summary>
/// Requests implementing this interface are eligible for caching.
/// </summary>
public interface ICacheableRequest
{
    string CacheKey { get; }
    TimeSpan? CacheDuration { get; }
}
