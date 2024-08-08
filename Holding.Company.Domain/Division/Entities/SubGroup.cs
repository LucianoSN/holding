namespace Holding.Company.Domain.Division.Entities;

public class SubGroup
{
    public SubGroup(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } 
}