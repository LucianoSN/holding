namespace Holding.Core.DomainObjects.Results;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult() { }

    public GenericCommandResult(object? data, bool success = false, string? message = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}
