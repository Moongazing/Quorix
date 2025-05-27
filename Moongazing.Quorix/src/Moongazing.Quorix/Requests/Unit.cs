namespace Moongazing.Quorix.Requests;

/// <summary>
/// Represents a void-like response type for commands and events.
/// </summary>
public readonly struct Unit
{
    public static readonly Unit Value = new();
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

/// <summary>
/// Represents an event to be published in the system.
/// </summary>
public interface IEvent : IRequest<Unit>
{
    string EventType { get; }
    object Data { get; }
}