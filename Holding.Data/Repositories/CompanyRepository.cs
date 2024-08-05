using Holding.Company.Domain.Company.Queries;
using Holding.Core.Data;
using Holding.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Holding.Data.Repositories;

public class CompanyRepository(DataContext context) : ICompanyRepository
{
    public void Dispose()
    {
        context?.Dispose();
    }

    public IUnitOfWork UnitOfWork => context;

    #region Company

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

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>>? GetCompanyByName(string name)
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

    #endregion

    #region Holding

    public async Task Create(Company.Domain.Company.Entities.Holding holding)
    {
        await context.Holdings.AddAsync(holding);
    }

    public async Task Update(Company.Domain.Company.Entities.Holding holding)
    {
        await Task.Run(() => context.Holdings.Update(holding));
    }

    public async Task<Company.Domain.Company.Entities.Holding>? GetHoldingById(Guid id)
    {
        return await context.Holdings
            .AsNoTracking()
            .FirstAsync(HoldingQueries.GetById(id));
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>>? GetHoldingByName(string name)
    {
        return await context.Holdings
            .AsNoTracking()
            .Where(HoldingQueries.GetByName(name))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHolding()
    {
        return await context.Holdings
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHoldingActivated()
    {
        return await context.Holdings
            .AsNoTracking()
            .Where(HoldingQueries.GetAllActivated())
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHoldingDeactivated()
    {
        return await context.Holdings
            .AsNoTracking()
            .Where(HoldingQueries.GetAllDeactivated())
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    #endregion
}