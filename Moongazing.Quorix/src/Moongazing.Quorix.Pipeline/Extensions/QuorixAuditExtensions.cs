using Microsoft.Extensions.DependencyInjection;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Audit;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixAuditExtensions
{
    public static IServiceCollection AddQuorixAudit<TLogger, TUserProvider>(this IServiceCollection services)
        where TLogger : class, IAuditLogger
        where TUserProvider : class, ICurrentUserProvider
    {
        services.AddScoped<IAuditLogger, TLogger>();
        services.AddScoped<ICurrentUserProvider, TUserProvider>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuditBehavior<,>));
        return services;
    }
}