using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Permissions;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class ChangeGroupNameCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeGroupNameCommand(string id, string name, string role = "")
    {
        Id = id.ToGuid();
        Name = name;
        
        AddNotifications(new ChangeGroupNameValidation(this, id, role));
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }    
}