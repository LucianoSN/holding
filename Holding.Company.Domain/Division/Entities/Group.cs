using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Division.Entities;

public class Group : Entity, IAggregateRoot
{
    protected Group()
    {
    }

    public Group(Guid companyId, string name)
    {
        CompanyId = companyId;
        Name = name;
    }

    public Guid CompanyId { get; private set; }
    public Company.Entities.Company? Company { get; private set; }

    public string Name { get; private set; }
    public IList<SubGroup> SubGroups { get; private set; } = new List<SubGroup>();

    public bool IsAccessible() => Active;

    public void ChangeName(string name) => Name = name;

    public bool AddSubGroup(SubGroup subGroup)
    {
        if (
            SubGroups.Any(s =>
                s.Name == subGroup.Name
                && s.Id == subGroup.Id
            )
        ) return false;

        SubGroups.Add(subGroup);
        return true;
    }
}