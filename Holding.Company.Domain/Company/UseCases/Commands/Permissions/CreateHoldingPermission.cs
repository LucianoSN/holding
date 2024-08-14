using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Company.UseCases.Commands.Permissions;

public class CreateHoldingPermission : BasePermission
{
    public CreateHoldingPermission(Role role) : base(role)
    {
        SetPermission();
    }

    protected sealed override void SetPermission()
    {
        // Not permission needed
    }
}