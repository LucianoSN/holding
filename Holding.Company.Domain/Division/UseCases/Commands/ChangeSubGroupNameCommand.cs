using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Permissions;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class ChangeSubGroupNameCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeSubGroupNameCommand(string id, string groupId, string name, string role = "")
    {
        Id = Parser.ToGuid(id);
        GroupId = Parser.ToGuid(groupId);
        Name = name;

        AddNotifications(new ChangeSubGroupNameValidation(this));
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
        AddNotifications(new CustomNotification().IsGuid(groupId, "GroupId", "GroupId is invalid"));

        AddNotifications(
            new CustomNotification().HasPermission(
                new ChangeSubGroupNamePermission(Parser.ToRole(role))
            )
        );
    }

    public Guid Id { get; private set; }
    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
}