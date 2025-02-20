namespace Holding.Core.DomainObjects.Results;

public class PagedCommandResult : GenericCommandResult
{
    public PagedCommandResult(
        object? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = 25,
        string? message = null
    )
        : base(data, true, message)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedCommandResult(object? data, bool success = false, string? message = null)
        : base(data, success, message) { }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
