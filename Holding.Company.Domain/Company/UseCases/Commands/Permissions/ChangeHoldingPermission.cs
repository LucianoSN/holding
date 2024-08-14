using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Company.UseCases.Commands.Permissions;

public class ChangeHoldingPermission : BasePermission
{
    public ChangeHoldingPermission(Role role) : base(role)
    {
    }

    protected override void SetPermission()
    {
        // Not permission needed
    }
}