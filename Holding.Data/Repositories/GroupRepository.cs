using Holding.Company.Domain.Division.Entities;
using Holding.Company.Domain.Division.Queries;
using Holding.Core.Data;
using Holding.Data.Contexts;

namespace Holding.Data.Repositories;

public class GroupRepository(DataContext context) : IGroupRepository
{
    public void Dispose()
    {
        context?.Dispose();
    }

    public IUnitOfWork Transact => context;

    #region Group

    public async Task Create(Group group)
    {
        await context.Groups.AddAsync(group);
    }

    public Task Update(Group group)
    {
        throw new NotImplementedException();
    }

    public Task<Group>? GetGroupById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Group>? GetGroupByIdWithSubGroups(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Group>>? GetGroupByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<Group>> GetAllGroups(int currentPage, int pageSize)
    {
        throw new NotImplementedException();
    }
    

    #endregion

    #region SubGroup

    public Task<SubGroup>? GetSubGroupById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SubGroup>>? GetSubGroupByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<SubGroup>> GetAllSubGroups(int currentPage, int pageSize)
    {
        throw new NotImplementedException();
    }

    #endregion
}