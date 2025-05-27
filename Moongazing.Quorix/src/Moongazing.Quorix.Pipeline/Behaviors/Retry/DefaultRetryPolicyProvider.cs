using Moongazing.Quorix.Pipeline.Behaviors.Retry;
using Polly;

public class DefaultRetryPolicyProvider : IRetryPolicyProvider
{
    public IAsyncPolicy CreatePolicy(IRetryableRequest request)
    {
        return Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(
                retryCount: request.MaxRetryAttempts,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)) + request.RetryDelay
            );
    }
}
