namespace Moongazing.Quorix.Requests;

public interface IRequest<out TResponse>
{
    string RequestId { get; }
    DateTime CreatedAt { get; }
}

public interface IRequest : IRequest<Unit> { }