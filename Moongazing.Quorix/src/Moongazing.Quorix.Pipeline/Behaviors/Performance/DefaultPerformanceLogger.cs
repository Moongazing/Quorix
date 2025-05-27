using Microsoft.Extensions.Logging;

namespace Moongazing.Quorix.Pipeline.Behaviors.Performance;

public class DefaultPerformanceLogger : IPerformanceLogger
{
    private readonly ILogger<DefaultPerformanceLogger> _logger;

    public DefaultPerformanceLogger(ILogger<DefaultPerformanceLogger> logger)
    {
        _logger = logger;
    }

    public void Log(string requestName, long elapsedMilliseconds, object request)
    {
        _logger.LogWarning("Slow request: {RequestName} took {Elapsed}ms. Payload: {@Request}",
            requestName, elapsedMilliseconds, request);
    }
}
