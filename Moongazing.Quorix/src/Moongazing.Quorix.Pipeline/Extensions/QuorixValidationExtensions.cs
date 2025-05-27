using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Pipeline.Behaviors.Validation;
using System.Reflection;

namespace Moongazing.Quorix.Pipeline.Extensions;

public static class QuorixValidationExtensions
{
    public static IServiceCollection AddQuorixValidation(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        services.AddValidatorsFromAssemblies(assembliesToScan);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
