namespace Moongazing.Quorix.Pipeline.Behaviors.Caching;

public interface ICacheProvider
{
    Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory, TimeSpan? duration);
    void Remove(string key);
}
