using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Mediator;


public interface ICommandBus
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    Task Send(IRequest request, CancellationToken cancellationToken = default);

    Task Publish<TEvent>(TEvent eventNotification, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    Task PublishAll<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
