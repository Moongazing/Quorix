namespace Moongazing.Quorix.Mediator;

/// <summary>
/// Delegate for invoking the next step in the request pipeline.
/// </summary>
public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();



