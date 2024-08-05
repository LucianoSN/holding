using Holding.Core.Data;

namespace Holding.Company.Domain.Company.Queries;

public interface ICompanyRepository : IRepository<Entities.Company>
{
    #region Company

    Task Create(Entities.Company company);
    Task Update(Entities.Company company);
    Task<Entities.Company>? GetCompanyById(Guid id);
    Task<Entities.Company>? GetCompanyByName(string name);
    Task<IEnumerable<Entities.Company>> GetCompanyByHoldingId(Guid holdingId);
    Task<IEnumerable<Entities.Company>> GetAllCompanies();
    Task<IEnumerable<Entities.Company>> GetAllCompaniesActivated();
    Task<IEnumerable<Entities.Company>> GetAllCompaniesDeactivated();

    #endregion

    #region Holding

    Task Create(Entities.Holding holding);
    Task Update(Entities.Holding holding);
    Task<Entities.Holding>? GetHoldingById(Guid id);
    Task<Entities.Holding>? GetHoldingByName(string name);
    Task<IEnumerable<Entities.Holding>> GetAllHolding();
    Task<IEnumerable<Entities.Holding>> GetAllHoldingActivated();
    Task<IEnumerable<Entities.Holding>> GetAllHoldingDeactivated();

    #endregion
}