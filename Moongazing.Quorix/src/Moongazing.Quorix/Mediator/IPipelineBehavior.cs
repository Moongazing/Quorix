using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Mediator;

/// <summary>
/// Represents a pipeline behavior in the request processing chain.
/// </summary>
public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
}
