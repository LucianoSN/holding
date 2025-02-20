using Flunt.Validations;
using Holding.Company.Domain.Division.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Division.UseCases.Commands.Validations;

public class CreateGroupValidation : Contract<CreateGroupCommand>
{
    public CreateGroupValidation(CreateGroupCommand command, string companyId, string role)
    {
        Requires()
            .IsNotNullOrEmpty(command.Name, "Name", "Name is required")
            .IsGreaterOrEqualsThan(
                command.Name.Length,
                3,
                "Name",
                "Name must be at least 3 characters"
            )
            .IsLowerOrEqualsThan(
                command.Name.Length,
                80,
                "Name",
                "Name must be at most 80 characters"
            );

        AddNotifications(
            new CustomNotification().IsGuid(companyId, "CompanyId", "CompanyId is invalid")
        );
        AddNotifications(new CustomNotification().HasPermission<CreateGroupPermission>(role));
    }
}
