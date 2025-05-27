using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Pipeline.Behaviors.RateLimiting;

public class RateLimitingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRateLimiterProvider limiter;

    public RateLimitingBehavior(IRateLimiterProvider limiter)
    {
        this.limiter = limiter;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not IRateLimitedRequest rateLimited)
            return await next();

        if (!limiter.Allow(rateLimited.RateLimitKey, rateLimited.MaxRequests, rateLimited.TimeWindow))
            throw new InvalidOperationException($"Rate limit exceeded for key: {rateLimited.RateLimitKey}");

        return await next();
    }
}
