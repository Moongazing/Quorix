using Moongazing.Quorix.Mediator;
using Moongazing.Quorix.Requests;
using System.Text.Json;

namespace Moongazing.Quorix.Pipeline.Behaviors.Audit;

public class AuditBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IAuditLogger auditLogger;
    private readonly ICurrentUserProvider currentUserProvider;

    public AuditBehavior(IAuditLogger auditLogger, ICurrentUserProvider currentUserProvider)
    {
        this.auditLogger = auditLogger;
        this.currentUserProvider = currentUserProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var userId = currentUserProvider.GetUserId();
        var action = typeof(TRequest).Name;
        var timestamp = DateTime.UtcNow;

        var entry = new AuditEntry
        {
            UserId = userId,
            Action = action,
            Timestamp = timestamp,
            RequestJson = JsonSerializer.Serialize(request)
        };

        try
        {
            var response = await next();
            entry.Success = true;
            await auditLogger.LogAsync(entry);
            return response;
        }
        catch (Exception ex)
        {
            entry.Success = false;
            entry.ErrorMessage = ex.Message;
            await auditLogger.LogAsync(entry);
            throw;
        }
    }
}
