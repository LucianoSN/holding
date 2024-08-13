using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Handlers;

public class ChangeGroupNameHandler(IGroupRepository repository)
    : IRequestHandler<ChangeGroupNameCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(ChangeGroupNameCommand command, 
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this group is invalid");
        
        // Get the group        
        var group = await repository.GetGroupById(command.Id);
        
        // Check if the group exists
        if (group == null)
            return new GenericCommandResult(null, false, "Group not found");
        
        // Update the group
        group.ChangeName(command.Name);

        // Save in the database
        await repository.Update(group);
        await repository.Transact.Commit();

        return new GenericCommandResult(group, true, "Group updated with success");
    }
}