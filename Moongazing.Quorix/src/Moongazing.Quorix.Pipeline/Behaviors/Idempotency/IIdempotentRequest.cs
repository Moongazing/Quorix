namespace Moongazing.Quorix.Pipeline.Behaviors.Idempotency;


/// <summary>
/// Request is idempotent and must not be re-processed with the same key.
/// </summary>
public interface IIdempotentRequest
{
    string IdempotencyKey { get; }
}
