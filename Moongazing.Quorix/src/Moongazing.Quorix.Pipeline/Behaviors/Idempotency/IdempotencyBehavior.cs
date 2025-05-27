using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Pipeline.Behaviors.Idempotency;

public class IdempotencyBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRequestTracker _tracker;

    public IdempotencyBehavior(IRequestTracker tracker)
    {
        _tracker = tracker;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not IIdempotentRequest idempotent)
            return await next();

        var key = idempotent.IdempotencyKey;

        if (await _tracker.ExistsAsync(key))
        {
            var cached = await _tracker.GetResponseAsync<TResponse>(key);
            return cached!;
        }

        var response = await next();
#pragma warning disable CS8604 // Possible null reference argument.
        await _tracker.StoreResponseAsync(key, response);
#pragma warning restore CS8604 // Possible null reference argument.

        return response;
    }
}
