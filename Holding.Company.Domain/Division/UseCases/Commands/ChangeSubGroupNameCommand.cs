using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class ChangeSubGroupNameCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeSubGroupNameCommand(string id, string groupId, string name, string role = "")
    {
        Id = id.ToGuid();
        GroupId = groupId.ToGuid();
        Name = name;

        AddNotifications(new ChangeSubGroupNameValidation(this, id, groupId, role));
    }

    public Guid Id { get; private set; }
    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
}