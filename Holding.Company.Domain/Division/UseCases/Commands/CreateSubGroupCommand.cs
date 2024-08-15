using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Permissions;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class CreateSubGroupCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateSubGroupCommand(string groupId, string name, string role = "")
    {
        GroupId = Parser.ToGuid(groupId);
        Name = name;
        
        AddNotifications(new CreateSubGroupValidation(this));
        AddNotifications(new CustomNotification().IsGuid(groupId, "GroupId", "GroupId is invalid"));
        AddNotifications(new CustomNotification().HasPermission<CreateSubGroupPermission>(role));
    }
        
    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
    
    public Entities.SubGroup ToEntity() => new(GroupId, Name);
}