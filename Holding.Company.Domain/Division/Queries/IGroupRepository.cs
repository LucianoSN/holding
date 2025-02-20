using Holding.Core.Data;

namespace Holding.Company.Domain.Division.Queries;

public interface IGroupRepository : IRepository<Entities.Group>
{
    #region Group

    Task Create(Entities.Group group);
    Task Update(Entities.Group group);
    Task<Entities.Group>? GetGroupById(Guid id);
    Task<Entities.Group>? GetGroupByIdWithSubGroupsTracking(Guid id);
    Task<IEnumerable<Entities.Group>>? GetGroupByName(string name);
    Task<PagedResponse<Entities.Group>> GetAllGroups(int currentPage, int pageSize);

    #endregion

    #region SubGroup

    Task<Entities.SubGroup>? GetSubGroupById(Guid id);
    Task<IEnumerable<Entities.SubGroup>>? GetSubGroupByName(string name);
    Task<PagedResponse<Entities.SubGroup>> GetAllSubGroups(int currentPage, int pageSize);

    #endregion
}
