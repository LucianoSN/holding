using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Handlers;

public class ChangeSubGroupNameHandler(IGroupRepository repository)
    : IRequestHandler<ChangeSubGroupNameCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(ChangeSubGroupNameCommand command, 
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this SubGroup is invalid");

        // Get the group        
        var group = await repository.GetGroupByIdWithSubGroupsTracking(command.GroupId);

        // Check if the group exists
        if (group == null)
            return new GenericCommandResult(null, false, "Group not found");

        // Change the subgroup name
        var changeSubGroupName = group.ChangeSubGroupName(command.Id, command.Name);

        // Check if the subgroup already exists
        if (!changeSubGroupName)
            return new GenericCommandResult(command.Notifications, false, "SubGroup already exists");
            
        await repository.Update(group);
        await repository.UnitOfWork.Commit();

        return new GenericCommandResult(
            group,
            changeSubGroupName,
            "SubGroup name changed with success"
        );
    }
}