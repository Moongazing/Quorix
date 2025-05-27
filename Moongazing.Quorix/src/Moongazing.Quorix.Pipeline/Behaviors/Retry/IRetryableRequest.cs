namespace Moongazing.Quorix.Pipeline.Behaviors.Retry;

public interface IRetryableRequest
{
    int MaxRetryAttempts { get; }
    TimeSpan RetryDelay { get; }
}
