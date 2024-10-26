namespace Employment.Domain.Shared;

public sealed class ValidationResult : ResponseModel, IValidationResult
{
    private ValidationResult(string[] props, string[] errors)
        : base(false, errors.Length > 0 ? errors[0] : "Validation failed")
    {
        PropertyNames = props;
        ErrorMessages = errors;
    }

    public string[] ErrorMessages { get; }

    public string[] PropertyNames { get; }

    public static ValidationResult WithErrors(string[] props, string[] errors) => new ValidationResult(props, errors);
}
