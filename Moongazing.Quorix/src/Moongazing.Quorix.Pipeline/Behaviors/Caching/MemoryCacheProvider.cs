using Microsoft.Extensions.Caching.Memory;

namespace Moongazing.Quorix.Pipeline.Behaviors.Caching;

public class MemoryCacheProvider : ICacheProvider
{
    private readonly IMemoryCache cache;

    public MemoryCacheProvider(IMemoryCache cache)
    {
        this.cache = cache;
    }

    public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory, TimeSpan? duration)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (cache.TryGetValue(key, out T value))
#pragma warning disable CS8603 // Possible null reference return.
            return value;
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        var result = await factory();

        var options = new MemoryCacheEntryOptions();
        if (duration.HasValue)
            options.SetAbsoluteExpiration(duration.Value);

        cache.Set(key, result, options);

        return result;
    }

    public void Remove(string key)
    {
        cache.Remove(key);
    }
}
