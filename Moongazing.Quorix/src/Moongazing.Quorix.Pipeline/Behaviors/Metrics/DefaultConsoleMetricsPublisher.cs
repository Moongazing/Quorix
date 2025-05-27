namespace Moongazing.Quorix.Pipeline.Behaviors.Metrics;

public class DefaultConsoleMetricsPublisher : IMetricsPublisher
{
    public Task PublishAsync(string requestName, long elapsedMs, bool success)
    {
        Console.WriteLine($"[Metrics] {requestName} took {elapsedMs}ms, success: {success}");
        return Task.CompletedTask;
    }
}
