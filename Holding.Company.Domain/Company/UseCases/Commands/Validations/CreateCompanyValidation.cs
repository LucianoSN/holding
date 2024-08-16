using Flunt.Validations;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.Validations.Notifications;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class CreateCompanyValidation : Contract<CreateCompanyCommand>
{
    public CreateCompanyValidation(CreateCompanyCommand command, string holdingId, string role)
    {
        Requires()
            .IsNotNullOrEmpty(command.Name, "Name", "Name is required")
            .IsGreaterOrEqualsThan(command.Name.Length, 3, "Name", "Name must be at least 3 characters")
            .IsLowerOrEqualsThan(command.Name.Length, 80, "Name", "Name must be at most 80 characters")
            
            .IsNotNullOrEmpty(command.AddressCountry, "AddressCountry", "AddressCountry is required")
            .IsGreaterOrEqualsThan(command.AddressCountry.Length, 3, "AddressCountry", "AddressName must be at least 3 characters")
            .IsLowerOrEqualsThan(command.AddressCountry.Length, 80, "AddressCountry", "AddressName must be at most 80 characters")
            
            .IsNotNullOrEmpty(command.AddressPostalCode, "AddressPostalCode", "AddressPostalCode is required")
            .IsGreaterOrEqualsThan(command.AddressPostalCode.Length, 3, "AddressPostalCode", "AddressPostalCode must be at least 3 characters")
            .IsLowerOrEqualsThan(command.AddressPostalCode.Length, 20, "AddressPostalCode", "AddressPostalCode must be at most 20 characters")
            
            .IsNotNullOrEmpty(command.AddressState, "AddressState", "AddressState is required")
            .IsGreaterOrEqualsThan(command.AddressState.Length, 3, "AddressState", "AddressState must be at least 3 characters")
            .IsLowerOrEqualsThan(command.AddressState.Length, 20, "AddressState", "AddressState must be at most 20 characters")
            
            .IsNotNullOrEmpty(command.AddressStreet, "AddressStreet", "AddressStreet is required")
            .IsGreaterOrEqualsThan(command.AddressStreet.Length, 3, "AddressStreet", "AddressStreet must be at least 3 characters")
            .IsLowerOrEqualsThan(command.AddressStreet.Length, 20, "AddressStreet", "AddressStreet must be at most 20 characters")
            
            .IsNotNullOrEmpty(command.ContactFullName, "ContactFullName", "ContactFullName is required")
            .IsGreaterOrEqualsThan(command.ContactFullName.Length, 3, "ContactFullName", "ContactFullName must be at least 3 characters")
            .IsLowerOrEqualsThan(command.ContactFullName.Length, 80, "ContactFullName", "ContactFullName must be at most 80 characters")
            
            .IsEmail(command.ContactEmail, "ContactEmail", "ContactEmail is invalid")
            .IsGreaterOrEqualsThan(command.ContactEmail.Length, 3, "ContactEmail", "ContactEmail must be at least 3 characters")
            .IsLowerOrEqualsThan(command.ContactEmail.Length, 50, "ContactEmail", "ContactEmail must be at most 50 characters");
        
        AddNotifications(new CustomNotification().IsGuid(holdingId, "HoldingId", "HoldingId is invalid"));
        AddNotifications(new CustomNotification().HasPermission<CreateCompanyPermission>(role));
    } 
}