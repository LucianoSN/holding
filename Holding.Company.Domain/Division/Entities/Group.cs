using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Division.Entities;

public class Group  : Entity, IAggregateRoot
{
    protected Group() { }
    
    public Group(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public IList<SubGroup> SubGroups { get; private set; } = new List<SubGroup>();
    
    public bool IsAccessible() => Active;
    
    public void ChangeName(string name) => Name = name;
    
    public void AddSubGroup(SubGroup subGroup)
    {
        if (SubGroups.Any(s => s.Name == subGroup.Name)) return;
        SubGroups.Add(subGroup);
    }
}