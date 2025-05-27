using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Pipeline.Behaviors.Retry;

public class RetryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRetryPolicyProvider _policyProvider;

    public RetryBehavior(IRetryPolicyProvider policyProvider)
    {
        _policyProvider = policyProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not IRetryableRequest retryable)
        {
            return await next();
        }

        var policy = _policyProvider.CreatePolicy(retryable);
        return await policy.ExecuteAsync(() => next());
    }
}
