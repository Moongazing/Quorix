using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Handlers;

/// <summary>
/// Handles a published event.
/// </summary>
public interface IEventHandler<in TEvent> : IRequestHandler<TEvent>
    where TEvent : IEvent
{
}
