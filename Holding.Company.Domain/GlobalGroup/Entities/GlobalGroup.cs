using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.GlobalGroup.Entities;

public class GlobalGroup(string name, string? description = null) : Entity, IAggregateRoot
{
    public string Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
    
    public void ChangeName(string name) => Name = name;
    public void ChangeDescription(string? description) => Description = description;
    
    public bool IsAccessible() => Active;
}