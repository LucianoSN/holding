namespace Holding.Core.DomainObjects.Results;

public class GenericCommandResult<TData> : ICommandResult
{
   public GenericCommandResult() { }
   
   public GenericCommandResult(TData? data, bool success = false, string? message = null)
   {
      Success = success;
      Message = message;
      Data = data;
   }

   public bool Success { get; set; }
   public string? Message { get; set; }
   public TData? Data { get; set; }
}