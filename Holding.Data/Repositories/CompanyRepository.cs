using Holding.Company.Domain.Company.Queries;
using Holding.Core.Data;
using Holding.Data.Contexts;

namespace Holding.Data.Repositories;

public class CompanyRepository(DataContext context) : ICompanyRepository
{
    public void Dispose()
    {
        context?.Dispose();
    }

    public IUnitOfWork UnitOfWork => context;
    
    public Task Create(Company.Domain.Company.Entities.Company company)
    {
        throw new NotImplementedException();
    }

    public Task Update(Company.Domain.Company.Entities.Company company)
    {
        throw new NotImplementedException();
    }

    public Task<Company.Domain.Company.Entities.Company>? GetCompanyById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Company.Domain.Company.Entities.Company>? GetCompanyByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetCompanyByHoldingId(Guid holdingId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompanies()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompaniesActivated()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompaniesDeactivated()
    {
        throw new NotImplementedException();
    }

    public Task Create(Company.Domain.Company.Entities.Holding holding)
    {
        throw new NotImplementedException();
    }

    public Task Update(Company.Domain.Company.Entities.Holding holding)
    {
        throw new NotImplementedException();
    }

    public Task<Company.Domain.Company.Entities.Holding>? GetHoldingById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Company.Domain.Company.Entities.Holding>? GetHoldingByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHolding()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHoldingActivated()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHoldingDeactivated()
    {
        throw new NotImplementedException();
    }
}