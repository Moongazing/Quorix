using System.Collections.Concurrent;

namespace Moongazing.Quorix.Pipeline.Behaviors.Idempotency;

public class InMemoryRequestTracker : IRequestTracker
{
    private readonly ConcurrentDictionary<string, object> _storage = new();

    public Task<bool> ExistsAsync(string key)
        => Task.FromResult(_storage.ContainsKey(key));

    public Task StoreResponseAsync(string key, object response)
    {
        _storage[key] = response;
        return Task.CompletedTask;
    }

    public Task<T?> GetResponseAsync<T>(string key)
    {
        if (_storage.TryGetValue(key, out var result))
            return Task.FromResult((T?)result);

        return Task.FromResult(default(T));
    }
}
