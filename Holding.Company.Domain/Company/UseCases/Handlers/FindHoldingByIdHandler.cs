using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class FindHoldingByIdHandler(ICompanyRepository repository)
    : IRequestHandler<FindHoldingByIdCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(
        FindHoldingByIdCommand command,
        CancellationToken cancellationToken
    )
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(
                command.Notifications,
                false,
                "Ops, this holding is invalid"
            );

        // Get the holding
        var holding = await repository.GetHoldingById(command.Id)!;

        // Check if the holding exists
        if (holding == null)
            return new GenericCommandResult(null, false, "Holding not found");

        return new GenericCommandResult(holding, true, "Holding found with success");
    }
}
