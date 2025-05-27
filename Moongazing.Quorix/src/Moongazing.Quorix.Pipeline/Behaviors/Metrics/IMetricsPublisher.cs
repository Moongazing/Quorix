namespace Moongazing.Quorix.Pipeline.Behaviors.Metrics;

public interface IMetricsPublisher
{
    Task PublishAsync(string requestName, long elapsedMs, bool success);
}
