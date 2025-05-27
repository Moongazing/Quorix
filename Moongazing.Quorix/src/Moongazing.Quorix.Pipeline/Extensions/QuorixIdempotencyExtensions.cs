using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Idempotency;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixIdempotencyExtensions
{
    public static IServiceCollection AddQuorixIdempotency(this IServiceCollection services)
    {
        services.TryAddSingleton<IRequestTracker, InMemoryRequestTracker>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IdempotencyBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixIdempotency<T>(this IServiceCollection services) where T : class, IRequestTracker
    {
        services.AddScoped<IRequestTracker, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IdempotencyBehavior<,>));
        return services;
    }
}
