using Polly;

namespace Moongazing.Quorix.Pipeline.Behaviors.Retry;

public interface IRetryPolicyProvider
{
    IAsyncPolicy CreatePolicy(IRetryableRequest request);
}


