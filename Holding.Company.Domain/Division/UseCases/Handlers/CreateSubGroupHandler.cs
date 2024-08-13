using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Handlers;

public class CreateSubGroupHandler(IGroupRepository repository)
    : IRequestHandler<CreateSubGroupCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(CreateSubGroupCommand command,
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this SubGroup is invalid");

        // Get the group        
        var group = await repository.GetGroupByIdWithSubGroups(command.GroupId);

        // Check if the group exists
        if (group == null)
            return new GenericCommandResult(null, false, "Group not found");

        // Create the subgroup
        var subGroup = command.ToEntity();

        // Add the subgroup to the group
        var addSubGroup = group.AddSubGroup(subGroup);

        // Check if the subgroup already exists
        if (!addSubGroup)
            return new GenericCommandResult(command.Notifications, false, "SubGroup already exists");
            
        await repository.Update(group);
        await repository.Transact.Commit();

        return new GenericCommandResult(
            subGroup,
            addSubGroup,
            "SubGroup created with success"
        );
    }
}