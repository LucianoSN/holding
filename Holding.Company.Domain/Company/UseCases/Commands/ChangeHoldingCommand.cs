using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class ChangeHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeHoldingCommand(
        string id,
        string name,
        string? description = null,
        string role = ""
    )
    {
        Id = Parser.ToGuid(id);
        Name = name;
        Description = description;

        AddNotifications(new ChangeHoldingValidation(this));
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
        AddNotifications(new CustomNotification().HasPermission<ChangeHoldingPermission>(role));
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
}