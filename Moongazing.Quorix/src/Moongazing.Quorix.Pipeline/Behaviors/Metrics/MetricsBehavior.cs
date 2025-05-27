using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;
using System.Diagnostics;

namespace Moongazing.Quorix.Pipeline.Behaviors.Metrics;

public class MetricsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IMetricsPublisher _metrics;

    public MetricsBehavior(IMetricsPublisher metrics)
    {
        _metrics = metrics;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var success = true;

        try
        {
            var result = await next();
            return result;
        }
        catch
        {
            success = false;
            throw;
        }
        finally
        {
            stopwatch.Stop();
            var requestName = typeof(TRequest).Name;
            await _metrics.PublishAsync(requestName, stopwatch.ElapsedMilliseconds, success);
        }
    }
}