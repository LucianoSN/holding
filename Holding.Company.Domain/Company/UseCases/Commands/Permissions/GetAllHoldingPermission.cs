using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Company.UseCases.Commands.Permissions;

public class GetAllHoldingPermission : BasePermission
{
    public GetAllHoldingPermission(Role role) : base(role)
    {
    }

    protected override void SetPermission()
    {
        // Not necessary to set permission for this command
    }
}