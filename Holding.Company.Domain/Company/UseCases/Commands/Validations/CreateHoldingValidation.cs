using Flunt.Validations;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class CreateHoldingValidation : Contract<CreateHoldingCommand>
{
    public CreateHoldingValidation(CreateHoldingCommand command, string role)
    {
        Requires()
            .IsNotNullOrEmpty(command.Name, "Name", "Name is required")
            .IsGreaterOrEqualsThan(command.Name.Length, 3, "Name", "Name must be at least 3 characters")
            .IsLowerOrEqualsThan(command.Name.Length, 80, "Name", "Name must be at most 80 characters");
        
        AddNotifications(new CustomNotification().HasPermission<CreateHoldingPermission>(role));
    } 
}