using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class TransferCompanyToAnotherHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public TransferCompanyToAnotherHoldingCommand(string companyId, string newHoldingId, string role = "")
    {
        CompanyId = companyId.ToGuid();
        NewHoldingId = newHoldingId.ToGuid();
        
        AddNotifications(new TransferCompanyToAnotherHoldingValidation(companyId, newHoldingId, role));
    }

    public Guid CompanyId { get; private set; }
    public Guid NewHoldingId { get; private set; }
}