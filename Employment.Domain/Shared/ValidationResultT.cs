namespace Employment.Domain.Shared;

public sealed class ValidationResult<TValue> : ResponseModel<TValue>, IValidationResult
{
    private ValidationResult(TValue value, string[] props, string[] errors)
        : base(
            value,
            errors.Length > 0 ? errors[0] : "Validation failed")
    {
        Value = value;
        ErrorMessages = errors;
        PropertyNames = props;
    }

    public TValue Value { get; }
    public string[] ErrorMessages { get; }
    public string[] PropertyNames { get; }

    public static ValidationResult<TValue> WithErrors(TValue value, string[] props, string[] errors)
        => new ValidationResult<TValue>(value, props, errors);
}
