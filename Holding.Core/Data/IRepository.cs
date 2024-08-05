using Holding.Core.DomainObjects;

namespace Holding.Core.Data;

public interface IRepository<T>: IDisposable where T : IAggregateRoot
{
   IUnitOfWork Persist { get; } 
}