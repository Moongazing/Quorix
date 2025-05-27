using Polly;
using Polly.CircuitBreaker;
namespace Moongazing.Quorix.Pipeline.Behaviors.CircuitBreaker;

public class DefaultCircuitBreakerPolicyProvider : ICircuitBreakerPolicyProvider
{
    private readonly Dictionary<string, IAsyncPolicy> _policies = new();
    private readonly object _lock = new();

    public AsyncCircuitBreakerPolicy CreatePolicy(ICircuitBreakerRequest request)
    {
        lock (_lock)
        {
            if (_policies.TryGetValue(request.CircuitBreakerKey, out var existingPolicy))
                return (AsyncCircuitBreakerPolicy)existingPolicy;

            var policy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: request.FailureThreshold,
                    durationOfBreak: request.DurationOfBreak
                );

            _policies[request.CircuitBreakerKey] = policy;
            return policy;
        }
    }
}
