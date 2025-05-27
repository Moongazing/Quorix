namespace Moongazing.Quorix.Requests.Common;

public abstract class BaseEvent : BaseRequest, IEvent
{
    public string EventType { get; protected set; }
    public object Data { get; protected set; }

    protected BaseEvent(string eventType, object data)
    {
        EventType = eventType;
        Data = data;
    }
}