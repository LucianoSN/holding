using Flunt.Validations;

namespace Holding.Company.Domain.Company.UseCases.Commands.Validations;

public class ChangeHoldingValidation : Contract<ChangeHoldingCommand>
{
    public ChangeHoldingValidation(ChangeHoldingCommand command)
    {
        Requires()
            .IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id is required")
            
            .IsNotNullOrEmpty(command.Name, "Name", "Name is required")
            .IsGreaterOrEqualsThan(command.Name.Length, 3, "Name", "Name must be at least 3 characters")
            .IsLowerOrEqualsThan(command.Name.Length, 80, "Name", "Name must be at most 80 characters");
    } 
}