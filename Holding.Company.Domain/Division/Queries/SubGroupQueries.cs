using System.Linq.Expressions;

namespace Holding.Company.Domain.Division.Queries;

public class SubGroupQueries
{
    public static Expression<Func<Entities.SubGroup, bool>> GetById(Guid id)
    {
        return x => x.Id == id && x.Active;
    }

    public static Expression<Func<Entities.SubGroup, bool>> GetByName(string name)
    {
        return x => x.Name == name && x.Active;
    }
}
