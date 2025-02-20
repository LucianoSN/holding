namespace Holding.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
