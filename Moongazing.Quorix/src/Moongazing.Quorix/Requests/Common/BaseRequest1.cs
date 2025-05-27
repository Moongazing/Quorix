namespace Moongazing.Quorix.Requests.Common;

public abstract class BaseRequest<TResponse> : IRequest<TResponse>
{
    public string RequestId { get; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}

