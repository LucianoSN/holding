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
        return await context.Companies.FirstOrDefaultAsync(CompanyQueries.GetById(id));
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>>? GetCompanyByName(string name)
    {
        return await context.Companies
            .Where(CompanyQueries.GetByName(name))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Company>> GetCompanyByHoldingId(Guid holdingId)
    {
        return await context.Companies
            .AsNoTracking()
            .Include(x => x.Holding)
            .Where(CompanyQueries.GetByHoldingId(holdingId))
            .ToListAsync();
    }

    public async Task<PagedResponse<Company.Domain.Company.Entities.Company>> GetAllCompanies(int currentPage, int pageSize)
    {
        var query = context.Companies
            .AsNoTracking()
            .OrderBy(x => x.Name);

        var companies = await query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Company.Domain.Company.Entities.Company>
        {
            Data = companies,
            TotalCount = count,
            CurrentPage = currentPage,
            PageSize = pageSize
        };
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
        return await context.Holdings.FirstOrDefaultAsync(HoldingQueries.GetById(id));
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>>? GetHoldingByName(string name)
    {
        return await context.Holdings
            .Where(HoldingQueries.GetByName(name))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Company.Domain.Company.Entities.Holding>> GetAllHoldings()
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