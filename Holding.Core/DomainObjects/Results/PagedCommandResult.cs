namespace Holding.Core.DomainObjects.Results;

public class PagedCommandResult<TData> : GenericCommandResult<TData>
{
    public PagedCommandResult(
        TData? data,
        int totalCount, 
        int currentPage = 1, 
        int pageSize = 25
    ) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    
    public PagedCommandResult(
        TData? data,
        bool success = false,
        string? message = null
    ) : base(data, success, message)
    {
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}