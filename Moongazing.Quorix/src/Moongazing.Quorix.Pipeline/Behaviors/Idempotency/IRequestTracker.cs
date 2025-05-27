namespace Moongazing.Quorix.Pipeline.Behaviors.Idempotency;

public interface IRequestTracker
{
    Task<bool> ExistsAsync(string key);
    Task StoreResponseAsync(string key, object response);
    Task<T?> GetResponseAsync<T>(string key);
}
