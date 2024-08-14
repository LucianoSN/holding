using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Division.UseCases.Commands.Permissions;

public class ChangeGroupNamePermission : BasePermission
{
    public ChangeGroupNamePermission(Role role) : base(role)
    {
        SetPermission();
    }

    protected sealed override void SetPermission()
    {
        SuperAdministratorHasPermission();
        AdministratorHasPermission();
    }
}