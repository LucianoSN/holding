using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class FindHoldingByIdCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public FindHoldingByIdCommand(string id, string role = "")
    {
        Id = id.ToGuid(); 
        
        AddNotifications(new FindHoldingByIdValidation(id, role));
    }
    
    public Guid Id { get; private set; }
}