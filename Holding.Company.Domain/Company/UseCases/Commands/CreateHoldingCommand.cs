using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class CreateHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateHoldingCommand(string name, string? description)
    {
        Name = name;
        Description = description;
        
        AddNotifications(new CreateHoldingValidation(this));
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    
    public Entities.Holding ToEntity() => new(Name, Description);
}