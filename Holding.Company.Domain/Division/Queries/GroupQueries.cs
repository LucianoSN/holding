using System.Linq.Expressions;

namespace Holding.Company.Domain.Division.Queries;

public class GroupQueries
{
    public static Expression<Func<Entities.Group, bool>> GetById(Guid id)
    {
        return x => x.Id == id && x.Active;
    }
    
    public static Expression<Func<Entities.Group, bool>> GetByName(string name)
    {
        return x => x.Name == name && x.Active;
    }
    
    public static Expression<Func<Entities.Group, bool>> GetAllActivated()
    {
        return x => x.Active;
    }
    
    public static Expression<Func<Entities.Group, bool>> GetAllDeactivated()
    {
        return x => !x.Active;
    }
}