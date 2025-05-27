using Moongazing.Quorix.Requests;

namespace Moongazing.Quorix.Handlers;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
