using Microsoft.Extensions.DependencyInjection;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Logging;

public static class QuorixLoggingExtensions
{
    public static IServiceCollection AddQuorixMicrosoftLogging(this IServiceCollection services)
    {
        services.AddScoped(typeof(ILoggingProvider), typeof(MicrosoftLoggerProvider<>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        return services;
    }

    public static IServiceCollection AddQuorixLogging<TLogger>(this IServiceCollection services)
        where TLogger : class, ILoggingProvider
    {
        services.AddScoped<ILoggingProvider, TLogger>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        return services;
    }

}
