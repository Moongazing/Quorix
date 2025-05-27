using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;
using System.Diagnostics;

namespace Moongazing.Quorix.Pipeline.Behaviors.Performance;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IPerformanceLogger _logger;
    private readonly int _thresholdMs;

    public PerformanceBehavior(IPerformanceLogger logger, int thresholdMs = 500)
    {
        _logger = logger;
        _thresholdMs = thresholdMs;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        var response = await next();

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > _thresholdMs)
        {
            var requestName = typeof(TRequest).Name;
            _logger.Log(requestName, stopwatch.ElapsedMilliseconds, request);
        }

        return response;
    }
}
