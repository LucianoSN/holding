using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class ChangeHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeHoldingCommand(Guid id, string name, string? description = null)
    {
        Id = id;
        Name = name;
        Description = description;
        
        AddNotifications(new ChangeHoldingValidation(this));
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
}