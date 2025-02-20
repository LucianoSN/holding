using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class CreateHoldingHandler(ICompanyRepository repository)
    : IRequestHandler<CreateHoldingCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(
        CreateHoldingCommand command,
        CancellationToken cancellationToken
    )
    {
        // Fast Fail Validation
        if (!command.IsValid)
        {
            return new GenericCommandResult(
                command.Notifications,
                false,
                "Ops, this holding is invalid"
            );
        }

        // Generate the Holding
        var holding = command.ToEntity();

        // Save in the database
        await repository.Create(holding);
        await repository.Persist.Commit();

        return new GenericCommandResult(holding, true, "Holding created");
    }
}
