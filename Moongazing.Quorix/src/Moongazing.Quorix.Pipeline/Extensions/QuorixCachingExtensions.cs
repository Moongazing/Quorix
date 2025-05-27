using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Caching;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixCachingExtensions
{
    public static IServiceCollection AddQuorixMemoryCaching(this IServiceCollection services)
    {
        services.TryAddSingleton<ICacheProvider, MemoryCacheProvider>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixCaching<T>(this IServiceCollection services) where T : class, ICacheProvider
    {
        services.AddScoped<ICacheProvider, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        return services;
    }
}
