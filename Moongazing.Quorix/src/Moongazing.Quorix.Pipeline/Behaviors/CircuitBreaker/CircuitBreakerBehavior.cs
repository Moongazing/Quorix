using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;
namespace Moongazing.Quorix.Pipeline.Behaviors.CircuitBreaker;

public class CircuitBreakerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICircuitBreakerPolicyProvider _policyProvider;

    public CircuitBreakerBehavior(ICircuitBreakerPolicyProvider policyProvider)
    {
        _policyProvider = policyProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ICircuitBreakerRequest circuitBreakerRequest)
        {
            return await next();
        }

        var policy = _policyProvider.CreatePolicy(circuitBreakerRequest);
        return await policy.ExecuteAsync(() => next()); 
    }

}
