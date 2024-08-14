using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class CreateHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateHoldingCommand(string name, string? description = null, string role = "")
    {
        Name = name;
        Description = description;
        
        AddNotifications(new CreateHoldingValidation(this));
        
        AddNotifications(
            new CustomNotification().HasPermission(
                new CreateHoldingPermission(Parser.ToRole(role))
            )
        );
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    
    public Entities.Holding ToEntity() => new(Name, Description);
}