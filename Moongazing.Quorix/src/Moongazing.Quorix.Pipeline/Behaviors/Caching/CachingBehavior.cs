using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Pipeline.Behaviors.Caching;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICacheProvider cache;

    public CachingBehavior(ICacheProvider cache)
    {
        this.cache = cache;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ICacheableRequest cacheable)
        {
            return await next();
        }

        return await cache.GetOrAddAsync<TResponse>(
            cacheable.CacheKey,
            () => next(),
            cacheable.CacheDuration
        );
    }
}
