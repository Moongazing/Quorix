namespace Moongazing.Quorix.Pipeline.Behaviors.CircuitBreaker;


public interface ICircuitBreakerRequest
{
    string CircuitBreakerKey { get; }
    int FailureThreshold { get; }          
    TimeSpan DurationOfBreak { get; }        
}
