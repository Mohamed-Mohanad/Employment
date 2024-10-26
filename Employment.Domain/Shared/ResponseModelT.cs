namespace Employment.Domain.Shared;

public class ResponseModel<TData> : ResponseModel
{

    public int? TotalCount { get; }
    public TData Data { get; }
    protected internal ResponseModel(TData data) : base(true)
    {
        Data = data;
    }

    protected internal ResponseModel(TData data, int totalCount) : base(true)
    {
        Data = data;
        TotalCount = totalCount;
    }

    protected internal ResponseModel(TData data, string message) : base(false, message)
    {
        Data = data;
    }

    public static implicit operator ResponseModel<TData>(TData? value) => Create(value);
}
