using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Division.Entities;

public class SubGroup  : Entity
{
    public SubGroup(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } 
}