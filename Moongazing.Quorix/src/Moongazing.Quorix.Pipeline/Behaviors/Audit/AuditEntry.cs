namespace Moongazing.Quorix.Pipeline.Behaviors.Audit;

public class AuditEntry
{
    public string UserId { get; set; } = default!;
    public string Action { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public bool Success { get; set; }
    public string RequestJson { get; set; } = default!;
    public string? ErrorMessage { get; set; }
}
