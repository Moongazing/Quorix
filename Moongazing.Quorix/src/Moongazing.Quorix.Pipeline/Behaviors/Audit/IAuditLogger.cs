namespace Moongazing.Quorix.Pipeline.Behaviors.Audit;

public interface IAuditLogger
{
    Task LogAsync(AuditEntry entry);
}
