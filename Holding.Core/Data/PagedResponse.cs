namespace Holding.Core.Data;

public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int TotalCount { get; set; } 
    public int CurrentPage { get; set; } 
    public int PageSize { get; set; } 
}