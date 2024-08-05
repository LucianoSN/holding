using Holding.Core.Data;

namespace Holding.Company.Domain.GlobalGroup.Queries;

public interface IGlobalGroupRepository : IRepository<Entities.GlobalGroup>
{
   Task<Entities.GlobalGroup>? GetById(Guid id); 
   Task<IEnumerable<Entities.GlobalGroup>> GetAll();
   Task<IEnumerable<Entities.GlobalGroup>> GetAllActivated();
   Task<IEnumerable<Entities.GlobalGroup>> GetAllDeactivated();
   
   Task Create(Entities.GlobalGroup globalGroup);
   Task Update(Entities.GlobalGroup globalGroup);
}