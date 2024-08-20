using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Core.Data;
using Holding.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Holding.Data.Repositories;

public class GroupRepository(DataContext context) : IGroupRepository
{
    public void Dispose()
    {
        context?.Dispose();
    }

    public IUnitOfWork Persist => context;

    #region Group

    public async Task Create(Group group)
    {
        await context.Groups.AddAsync(group);
    }

    public async Task Update(Group group)
    {
        await Task.Run(() => context.Groups.Update(group));
    }

    public async Task<Group>? GetGroupById(Guid id)
    {
       return await context.Groups.FirstOrDefaultAsync(GroupQueries.GetById(id));
    }

    public async Task<Group>? GetGroupByIdWithSubGroupsTracking(Guid id)
    {
       return await context.Groups
           .Include(x => x.SubGroups)
           .FirstOrDefaultAsync(GroupQueries.GetById(id));
    }

    public async Task<IEnumerable<Group>>? GetGroupByName(string name)
    {
        return await context.Groups
            .Where(GroupQueries.GetByName(name))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<PagedResponse<Group>> GetAllGroups(int currentPage, int pageSize)
    {
        var query = context.Groups
            .AsNoTracking()
            .OrderBy(x => x.Name);

        var groups = await query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<Group>
        {
            Data = groups,
            TotalCount = count,
            CurrentPage = currentPage,
            PageSize = pageSize
        };
    }

    #endregion

    #region SubGroup

    public async Task<SubGroup>? GetSubGroupById(Guid id)
    {
        return await context.SubGroups.FirstOrDefaultAsync(SubGroupQueries.GetById(id));
    }

    public async Task<IEnumerable<SubGroup>>? GetSubGroupByName(string name)
    {
       return await context.SubGroups
           .Where(SubGroupQueries.GetByName(name))
           .OrderBy(x => x.Name)
           .ToListAsync();
    }

    public async Task<PagedResponse<SubGroup>> GetAllSubGroups(int currentPage, int pageSize)
    {
        var query = context.SubGroups
            .AsNoTracking()
            .OrderBy(x => x.Name);

        var subGroups = await query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await query.CountAsync();

        return new PagedResponse<SubGroup>
        {
            Data = subGroups,
            TotalCount = count,
            CurrentPage = currentPage,
            PageSize = pageSize
        };
    }

    #endregion
}