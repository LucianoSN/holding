using Holding.Core.DomainObjects;
using Holding.Core.Enumerators;

namespace Holding.Company.Domain.Company.UseCases.Commands.Permissions;

public class TransferCompanyToAnotherHoldingPermission : BasePermission
{
    public TransferCompanyToAnotherHoldingPermission(Role role) : base(role)
    {
    }

    protected override void SetPermission()
    {
        // Not permissions needed
    }
}