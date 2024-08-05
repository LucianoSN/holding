using Holding.Core.Data;

namespace Holding.Company.Domain.Company.Queries;

public interface ICompanyRepository : IRepository<Entities.Company>
{
   Task Create(Entities.Company company);
   Task Update(Entities.Company company);
   Task<Entities.Company>? GetCompanyById(Guid id); 
   Task<IEnumerable<Entities.Company>> GetCompanyByGlobalGroupId(Guid globalGroupId);
   Task<IEnumerable<Entities.Company>> GetAllCompanies();
   Task<IEnumerable<Entities.Company>> GetAllCompaniesActivated();
   Task<IEnumerable<Entities.Company>> GetAllCompaniesDeactivated();
   
   Task Create(Entities.GlobalGroup globalGroup);
   Task Update(Entities.GlobalGroup globalGroup);
   Task<Entities.GlobalGroup>? GetGlobalGroupById(Guid id); 
   Task<IEnumerable<Entities.GlobalGroup>> GetAllGlobalGroup();
   Task<IEnumerable<Entities.GlobalGroup>> GetAllGlobalGroupActivated();
   Task<IEnumerable<Entities.GlobalGroup>> GetAllGlobalGroupDeactivated();
}