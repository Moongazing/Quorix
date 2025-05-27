using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moongazing.Quorix.Handlers;
using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Mediator;

public class CommandBusMediator : ICommandBus
{
    private readonly IServiceProvider provider;
    private readonly ILogger<CommandBusMediator> logger;

    public CommandBusMediator(IServiceProvider provider, ILogger<CommandBusMediator> logger)
    {
        this.provider = provider;
        this.logger = logger;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        var handler = provider.GetService(handlerType) ?? throw new InvalidOperationException($"No handler found for request type: {requestType.FullName}");

        // Pipeline
        var behaviors = provider
            .GetServices(typeof(IPipelineBehavior<,>).MakeGenericType(requestType, typeof(TResponse)))
            .Cast<dynamic>()
            .Reverse()
            .ToList();

        RequestHandlerDelegate<TResponse> handlerDelegate = () =>
        {
            var handleMethod = handlerType.GetMethod("Handle");
            return (Task<TResponse>)handleMethod!.Invoke(handler, [request, cancellationToken])!;
        };

        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.Handle((dynamic)request, next, cancellationToken);
        }

        return await handlerDelegate();
    }

    public async Task Send(IRequest request, CancellationToken cancellationToken = default)
    {
        await Send<Unit>(request, cancellationToken);
    }

    public async Task Publish<TEvent>(TEvent eventNotification, CancellationToken cancellationToken = default)
        where TEvent : IEvent
    {
        var handlers = provider.GetServices<IEventHandler<TEvent>>();
        var tasks = handlers.Select(h => h.Handle(eventNotification, cancellationToken));
        await Task.WhenAll(tasks);
    }

    public async Task PublishAll<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken = default)
        where TEvent : IEvent
    {
        foreach (var e in events)
        {
            await Publish(e, cancellationToken);
        }
    }
}
