using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class CreateSubGroupCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateSubGroupCommand(string groupId, string name, string role = "")
    {
        GroupId = groupId.ToGuid();
        Name = name;
        
        AddNotifications(new CreateSubGroupValidation(this, groupId, role));
    }
        
    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
    
    public Entities.SubGroup ToEntity() => new(GroupId, Name);
}