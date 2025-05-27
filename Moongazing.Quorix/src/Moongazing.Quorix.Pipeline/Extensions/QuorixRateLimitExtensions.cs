using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.RateLimiting;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixRateLimitExtensions
{
    public static IServiceCollection AddQuorixRateLimiting(this IServiceCollection services)
    {
        services.TryAddSingleton<IRateLimiterProvider, InMemoryRateLimiterProvider>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RateLimitingBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixRateLimiting<T>(this IServiceCollection services) where T : class, IRateLimiterProvider
    {
        services.AddScoped<IRateLimiterProvider, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RateLimitingBehavior<,>));
        return services;
    }
}
