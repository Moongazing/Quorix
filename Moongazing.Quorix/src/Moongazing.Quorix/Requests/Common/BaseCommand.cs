namespace Moongazing.Quorix.Requests.Common;

public abstract class BaseCommand<TResponse> : BaseRequest<TResponse>, ICommand<TResponse>
{
}
public abstract class BaseCommand : BaseCommand<Unit>, ICommand
{
}
