using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class TransferCompanyToAnotherHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public TransferCompanyToAnotherHoldingCommand(string companyId, string newHoldingId, string role = "")
    {
        CompanyId = companyId.ToGuid();
        NewHoldingId = newHoldingId.ToGuid();
        
        AddNotifications(new CustomNotification().IsGuid(companyId, "CompanyId", "CompanyId is invalid"));
        AddNotifications(new CustomNotification().IsGuid(newHoldingId, "NewHoldingId", "NewHoldingId is invalid"));
        AddNotifications(new CustomNotification().HasPermission<TransferCompanyToAnotherHoldingPermission>(role));
    }

    public Guid CompanyId { get; private set; }
    public Guid NewHoldingId { get; private set; }
}