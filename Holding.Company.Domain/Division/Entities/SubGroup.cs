using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Division.Entities;

public class SubGroup : Entity
{
    public SubGroup(Guid groupId, string name)
    {
        GroupId = groupId;
        Name = name;
    }
    
    public Guid GroupId { get; private set; }
    public Group? Group { get; private set; }

    public string Name { get; private set; } 
    
    public void ChangeName(string name) => Name = name;
}