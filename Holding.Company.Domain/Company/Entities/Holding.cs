using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Company.Entities;

public class Holding(string name, string? description = null) : Entity
{
    public string Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
    
    public void ChangeName(string name) => Name = name;
    public void ChangeDescription(string? description) => Description = description;
    
    public bool IsAccessible() => Active;
}