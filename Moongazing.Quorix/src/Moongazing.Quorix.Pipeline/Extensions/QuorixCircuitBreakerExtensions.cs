using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.CircuitBreaker;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixCircuitBreakerExtensions
{
    public static IServiceCollection AddQuorixCircuitBreaker(this IServiceCollection services)
    {
        services.TryAddSingleton<ICircuitBreakerPolicyProvider, DefaultCircuitBreakerPolicyProvider>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CircuitBreakerBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixCircuitBreaker<T>(this IServiceCollection services) where T : class, ICircuitBreakerPolicyProvider
    {
        services.AddScoped<ICircuitBreakerPolicyProvider, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CircuitBreakerBehavior<,>));
        return services;
    }
}
