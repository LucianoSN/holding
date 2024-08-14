using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Company.UseCases.Commands.Permissions;

public class ChangeCompanyPermission : BasePermission
{
    public ChangeCompanyPermission(Role role) : base(role)
    {
        SetPermission();
    } 
    
    protected sealed override void SetPermission()
    {
        SuperAdministratorHasPermission();
    }
}