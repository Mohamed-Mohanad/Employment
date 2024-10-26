namespace Employment.Domain.Shared;

public class ResponseModel
{
    public bool IsSuccess { get; }
    public string Message { get; }
    protected internal ResponseModel(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message ?? (isSuccess ? "Success" : "Failure");
    }

    public static ResponseModel Success()
        => new(true);

    public static ResponseModel<TValue> Success<TValue>(TValue value)
        => new(value);

    public static ResponseModel<TValue> Success<TValue>(TValue value, string message)
         => new(value, message);

    public static ResponseModel<TValue> Success<TValue>(TValue value, int totalCount)
        => new(value, totalCount);

    public static ResponseModel Failure(string message)
        => new(false, message);

    public static ResponseModel<TValue> Failure<TValue>(string message) =>
       new(default!, message);

    public static ResponseModel<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>("null value");
}
