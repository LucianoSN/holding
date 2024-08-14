using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class FindHoldingByIdCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public FindHoldingByIdCommand(string id, string role = "")
    {
        Id = Parser.ToGuid(id); 
        
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));

        AddNotifications(
            new CustomNotification().HasPermission(
                new FindHoldingPermission(Parser.ToRole(role))
            )
        );
    }
    
    public Guid Id { get; private set; }
}