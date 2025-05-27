using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Metrics;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixMetricsExtensions
{
    public static IServiceCollection AddQuorixMetrics(this IServiceCollection services)
    {
        services.TryAddSingleton<IMetricsPublisher, DefaultConsoleMetricsPublisher>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MetricsBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixMetrics<T>(this IServiceCollection services) where T : class, IMetricsPublisher
    {
        services.AddScoped<IMetricsPublisher, T>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MetricsBehavior<,>));
        return services;
    }
}