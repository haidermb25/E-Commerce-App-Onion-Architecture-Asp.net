using FluentValidation.Results;

namespace Core.Errors;

public class DomainValidationError(List<ValidationFailure> errors, string? message = "Validation Error") : DomainError(message!)
{
    public new string Type { get; } = "ValidationError";

    public List<ValidationFailure> Errors { get; private set; } = errors;
}
