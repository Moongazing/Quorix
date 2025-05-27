using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Performance;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixPerformanceExtensions
{
    public static IServiceCollection AddQuorixPerformance(this IServiceCollection services, int thresholdMs = 500)
    {
        services.TryAddSingleton<IPerformanceLogger, DefaultPerformanceLogger>();
        services.AddScoped(typeof(IPipelineBehavior<,>), provider =>
        {
            var logger = provider.GetRequiredService<IPerformanceLogger>();
#pragma warning disable CS8603 // Possible null reference return.
            return Activator.CreateInstance(typeof(PerformanceBehavior<,>), logger, thresholdMs);
#pragma warning restore CS8603 // Possible null reference return.
        });

        return services;
    }

    public static IServiceCollection AddQuorixPerformance<TLogger>(this IServiceCollection services, int thresholdMs = 500)
        where TLogger : class, IPerformanceLogger
    {
        services.AddScoped<IPerformanceLogger, TLogger>();
        services.AddScoped(typeof(IPipelineBehavior<,>), provider =>
        {
            var logger = provider.GetRequiredService<IPerformanceLogger>();
#pragma warning disable CS8603 // Possible null reference return.
            return Activator.CreateInstance(typeof(PerformanceBehavior<,>), logger, thresholdMs);
#pragma warning restore CS8603 // Possible null reference return.
        });

        return services;
    }
}
