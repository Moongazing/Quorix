namespace Moongazing.Quorix.Pipeline.Behaviors.Validation;

/// <summary>
/// Represents one or more validation failures.
/// </summary>
public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors;
    }
}
