namespace Moongazing.Quorix.Pipeline.Behaviors.RateLimiting;

/// <summary>
/// Request implements this to opt into rate limiting.
/// </summary>
public interface IRateLimitedRequest
{
    string RateLimitKey { get; }         
    int MaxRequests { get; }
    TimeSpan TimeWindow { get; }
}
