using Holding.Core.DomainObjects;
using Holding.Core.ValueObjects;

namespace Holding.Company.Domain.Company.Entities;

public class Company(Guid holdingId, string name, Address address, Contact contact)
    : Entity, IAggregateRoot
{
    public Guid HoldingId { get; private set; } = holdingId;
    public string Name { get; private set; } = name;
    public Address Address { get; private set; } = address;
    public Contact Contact { get; private set; } = contact;
    
    public bool IsAccessible() => Active;
    public void ChangeName(string name) => Name = name;
    public void ChangeAddress(Address address) => Address = address;
    public void ChangeContact(Contact contact) => Contact = contact;
}