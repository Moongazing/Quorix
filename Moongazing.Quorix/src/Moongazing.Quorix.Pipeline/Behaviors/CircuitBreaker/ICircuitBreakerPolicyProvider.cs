using Polly.CircuitBreaker;

namespace Moongazing.Quorix.Pipeline.Behaviors.CircuitBreaker;

public interface ICircuitBreakerPolicyProvider
{
    AsyncCircuitBreakerPolicy CreatePolicy(ICircuitBreakerRequest request);
}
