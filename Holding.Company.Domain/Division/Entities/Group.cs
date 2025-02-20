using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Division.Entities;

public class Group : Entity, IAggregateRoot
{
    protected Group() { }

    public Group(Guid companyId, string name)
    {
        CompanyId = companyId;
        Name = name;
    }

    public Guid CompanyId { get; private set; }
    public Company.Entities.Company? Company { get; private set; }

    public string Name { get; private set; }
    public IList<SubGroup> SubGroups { get; private set; } = [];

    public bool IsAccessible() => Active;

    public void ChangeName(string name) => Name = name;

    public bool AddSubGroup(SubGroup subGroup)
    {
        if (subGroup.GroupId != Id)
            return false;

        if (SubGroups.Any(s => s.Name == subGroup.Name && Id == subGroup.GroupId))
            return false;

        SubGroups.Add(subGroup);
        return true;
    }

    public bool ChangeSubGroupName(Guid subGroupId, string name)
    {
        var subGroup = SubGroups.FirstOrDefault(s => s.Id == subGroupId);
        if (subGroup is null)
            return false;

        foreach (var sub in SubGroups)
            if (sub.Name == name)
                return false;

        subGroup.ChangeName(name);
        return true;
    }
}
