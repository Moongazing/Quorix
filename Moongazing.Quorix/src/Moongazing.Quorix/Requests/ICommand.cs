namespace Moongazing.Quorix.Requests;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
public interface ICommand : ICommand<Unit>
{
}