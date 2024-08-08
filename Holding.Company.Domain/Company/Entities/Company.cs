using Holding.Core.DomainObjects;
using Holding.Core.ValueObjects;

namespace Holding.Company.Domain.Company.Entities;

public class Company : Entity, IAggregateRoot
{
    protected Company() { }
    
    public Company(Guid holdingId, string name, Address address, Contact contact)
    {
       HoldingId = holdingId;
       Name = name;
       Address = address;
       Contact = contact;
    }
    
    public Guid HoldingId { get; private set; }
    public Holding? Holding { get; private set; }
    
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public Contact Contact { get; private set; }

    public bool IsAccessible() => Active;
    public void ChangeName(string name) => Name = name;
    public void ChangeAddress(Address address) => Address = address;
    public void ChangeContact(Contact contact) => Contact = contact;
    public void ChangeHolding(Guid holdingId) => HoldingId = holdingId;
}