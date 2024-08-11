using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Handlers;

public class CreateGroupHandler(IGroupRepository repository)
    : IRequestHandler<CreateGroupCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(CreateGroupCommand command,
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(
                command.Notifications,
                false,
                "Ops, this group is invalid"
            );

        // Generate the Group
        var group = command.ToEntity();

        // Save in the database
        await repository.Create(group);

        return new GenericCommandResult(group, true, "Group created");
    }
}