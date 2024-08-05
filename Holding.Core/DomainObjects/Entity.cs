namespace Holding.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public bool Active { get; private set; } = true;

    public Entity() => Id = new();
    
    public void Activate() => Active = true;
    public void Deactivate() => Active = false;
    public void ToggleActive() => Active = !Active;
    public void ChangeActive(bool active) => Active = active;
}