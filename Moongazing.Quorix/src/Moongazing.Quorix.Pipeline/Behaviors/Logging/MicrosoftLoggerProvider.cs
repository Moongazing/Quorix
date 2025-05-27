using Microsoft.Extensions.Logging;

namespace Moongazing.Quorix.Pipeline.Behaviors.Logging;

public class MicrosoftLoggerProvider<TRequest> : ILoggingProvider
{
    private readonly ILogger<TRequest> logger;

    public MicrosoftLoggerProvider(ILogger<TRequest> logger)
    {
        this.logger = logger;
    }

    public void LogInfo(string message, object context)
    {
        logger.LogInformation("{Message} {@Context}", message, context);
    }

    public void LogWarning(string message, object context)
    {
        logger.LogWarning("{Message} {@Context}", message, context);
    }

    public void LogError(string message, Exception exception, object context)
    {
        logger.LogError(exception, "{Message} {@Context}", message, context);
    }
}
