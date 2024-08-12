using Flunt.Validations;

namespace Holding.Company.Domain.Division.UseCases.Commands.Validations;

public class CreateSubGroupValidation : Contract<CreateSubGroupCommand>
{
    public CreateSubGroupValidation(CreateSubGroupCommand command)
    {
        Requires()
            .IsNotNullOrEmpty(command.Name, "Name", "Name is required")
            .IsGreaterOrEqualsThan(command.Name.Length, 3, "Name", "Name must be at least 3 characters")
            .IsLowerOrEqualsThan(command.Name.Length, 80, "Name", "Name must be at most 80 characters");
    } 
}