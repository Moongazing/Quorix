using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;
using System.Diagnostics;

namespace Moongazing.Quorix.Pipeline.Behaviors.Logging;

/// <summary>
/// Logs request handling lifecycle.
/// </summary>
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILoggingProvider logger;

    public LoggingBehavior(ILoggingProvider logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        logger.LogInfo($"Handling {requestName}", request);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            var response = await next();
            stopwatch.Stop();
#pragma warning disable CS8604 // Possible null reference argument.
            logger.LogInfo($"{requestName} completed in {stopwatch.ElapsedMilliseconds}ms", response);
#pragma warning restore CS8604 // Possible null reference argument.
            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            logger.LogError($"{requestName} failed after {stopwatch.ElapsedMilliseconds}ms", ex, request);
            throw;
        }
    }
}
