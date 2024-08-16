using Flunt.Validations;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class FindCompanyByIdValidation : Contract<FindCompanyByIdCommand>
{
    public FindCompanyByIdValidation(string id, string role)
    {
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
        AddNotifications(new CustomNotification().HasPermission<FindCompanyPermission>(role));
    } 
}