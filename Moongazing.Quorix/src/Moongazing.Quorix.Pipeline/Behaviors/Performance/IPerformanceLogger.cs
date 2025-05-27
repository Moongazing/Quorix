namespace Moongazing.Quorix.Pipeline.Behaviors.Performance;

/// <summary>
/// Logs slow-performing requests for diagnostics.
/// </summary>
public interface IPerformanceLogger
{
    void Log(string requestName, long elapsedMilliseconds, object request);
}
