using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class ChangeHoldingHandler(ICompanyRepository repository)
    : IRequestHandler<ChangeHoldingCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(ChangeHoldingCommand command,
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this holding is invalid");

        // Get the holding        
        var holding = await repository.GetHoldingById(command.Id);

        // Check if the holding exists
        if (holding == null)
            return new GenericCommandResult(null, false, "Holding not found");

        // Update the holding
        holding.ChangeName(command.Name);
        holding.ChangeDescription(command.Description);

        // Save in the database
        await repository.Update(holding);
        await repository.Transact.Commit();

        return new GenericCommandResult(holding, true, "Holding updated with success");
    }
}