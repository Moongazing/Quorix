namespace Moongazing.Quorix.Pipeline.Behaviors.Logging;

/// <summary>
/// Logging abstraction to decouple from specific loggers.
/// </summary>
public interface ILoggingProvider
{
    void LogInfo(string message, object context);
    void LogWarning(string message, object context);
    void LogError(string message, Exception exception, object context);
}
