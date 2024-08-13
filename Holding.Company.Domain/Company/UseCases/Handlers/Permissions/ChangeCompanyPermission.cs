using Holding.Core.DomainObjects;

namespace Holding.Company.Domain.Company.UseCases.Handlers.Permissions;

public class ChangeCompanyPermission : BasePermission
{
    public ChangeCompanyPermission()
    {
        SetPermission();
    } 
    
    protected sealed override void SetPermission()
    {
        ChangePartner(true);
        ChangeSuperAdministrator(true);
    }
}