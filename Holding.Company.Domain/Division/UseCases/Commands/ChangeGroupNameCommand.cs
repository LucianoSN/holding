using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class ChangeGroupNameCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeGroupNameCommand(string id, string name)
    {
        Id = Parser.ToGuid(id);
        Name = name;
        
        AddNotifications(new ChangeGroupNameValidation(this));
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }    
}