using System.Linq.Expressions;

namespace Holding.Company.Domain.Company.Queries;

public static class HoldingQueries
{
    public static Expression<Func<Entities.Holding, bool>> GetById(Guid id)
    {
        return x => x.Id == id && x.Active;
    }
    
    public static Expression<Func<Entities.Holding, bool>> GetByName(string name)
    {
        return x => x.Name == name && x.Active;
    }
    
    public static Expression<Func<Entities.Holding, bool>> GetAllActivated()
    {
        return x => x.Active;
    }
    
    public static Expression<Func<Entities.Holding, bool>> GetAllDeactivated()
    {
        return x => !x.Active;
    }
}