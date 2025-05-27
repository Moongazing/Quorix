using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Retry;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixRetryExtensions
{
    public static IServiceCollection AddQuorixRetry(this IServiceCollection services)
    {
        services.TryAddSingleton<IRetryPolicyProvider, DefaultRetryPolicyProvider>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RetryBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixRetry<T>(this IServiceCollection services) where T : class, IRetryPolicyProvider
    {
        services.AddScoped<IRetryPolicyProvider, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RetryBehavior<,>));
        return services;
    }
}
