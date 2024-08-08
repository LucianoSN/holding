using Flunt.Notifications;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class TransferCompanyToAnotherHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public TransferCompanyToAnotherHoldingCommand(string companyId, string newHoldingId)
    {
        CompanyId = Parser.ToGuid(companyId);
        NewHoldingId = Parser.ToGuid(newHoldingId);
        
        AddNotifications(new CustomNotification().IsGuid(companyId, "CompanyId", "CompanyId is invalid"));
        AddNotifications(new CustomNotification().IsGuid(newHoldingId, "NewHoldingId", "NewHoldingId is invalid"));
    }

    public Guid CompanyId { get; private set; }
    public Guid NewHoldingId { get; private set; }
}