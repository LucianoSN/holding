using Flunt.Notifications;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class FindHoldingByIdCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public FindHoldingByIdCommand(string id)
    {
        Id = Parser.ToGuid(id); 
        
        if (!Parser.IsGuid(id))
            AddNotification("Id", "Id is invalid");
    }
    
    public Guid Id { get; private set; }
}