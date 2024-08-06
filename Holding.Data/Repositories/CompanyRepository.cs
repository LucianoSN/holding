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

    public IUnitOfWork Transact => context;

    #region Company

    public async Task Create(Company.Domain.Company.Entities.Company company)
    {
        await context.Companies.AddAsync(company);
    }

    public async Task Update(Company.Domain.Company.Entities.Company company)
    {
        await Task.Run(() => context.Companies.Update(company));
    }

    public async Task<Company.Domain.Company.Entities.Company>? GetCompanyById(Guid id)
    {
        return await context.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(CompanyQueries.GetById(id));
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>>? GetCompanyByName(string name)
    {
        return await context.Companies
            .AsNoTracking()
            .Where(CompanyQueries.GetByName(name))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetCompanyByHoldingId(Guid holdingId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompanies()
    {
        return await context.Companies
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompaniesActivated()
    {
        return await context.Companies
            .AsNoTracking()
            .Where(CompanyQueries.GetAllActivated())
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetAllCompaniesDeactivated()
    {
        return await context.Companies
            .AsNoTracking()
            .Where(CompanyQueries.GetAllDeactivated())
            .OrderBy(x => x.Name)
            .ToListAsync();
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
            .FirstOrDefaultAsync(HoldingQueries.GetById(id));
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