using Flunt.Validations;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class FindHoldingByIdValidation : Contract<FindHoldingByIdCommand>
{
    public FindHoldingByIdValidation(string id, string role)
    {
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
        AddNotifications(new CustomNotification().HasPermission<FindHoldingPermission>(role));
    } 
}