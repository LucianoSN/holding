using Flunt.Validations;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class TransferCompanyToAnotherHoldingValidation
    : Contract<TransferCompanyToAnotherHoldingCommand>
{
    public TransferCompanyToAnotherHoldingValidation(
        string companyId,
        string newHoldingId,
        string role
    )
    {
        AddNotifications(
            new CustomNotification().IsGuid(companyId, "CompanyId", "CompanyId is invalid")
        );
        AddNotifications(
            new CustomNotification().IsGuid(newHoldingId, "NewHoldingId", "NewHoldingId is invalid")
        );
        AddNotifications(
            new CustomNotification().HasPermission<TransferCompanyToAnotherHoldingPermission>(role)
        );
    }
}
