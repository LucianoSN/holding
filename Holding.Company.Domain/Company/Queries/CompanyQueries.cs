using System.Linq.Expressions;

namespace Holding.Company.Domain.Company.Queries;

public static class CompanyQueries
{
    public static Expression<Func<Entities.Company, bool>> GetById(Guid id)
    {
        return x => x.Id == id && x.Active;
    }
    
    public static Expression<Func<Entities.Company, bool>> GetByHoldingId(Guid holdingId)
    {
        return x => x.HoldingId == holdingId && x.Active;
    }
    
    public static Expression<Func<Entities.Company, bool>> GetByName(string name)
    {
        return x => x.Name == name;
    }
    
    public static Expression<Func<Entities.Company, bool>> GetAllActivated()
    {
        return x => x.Active;
    }
    
    public static Expression<Func<Entities.Company, bool>> GetAllDeactivated()
    {
        return x => !x.Active;
    }
}