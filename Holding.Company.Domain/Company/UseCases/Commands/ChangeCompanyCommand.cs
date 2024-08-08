using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class ChangeCompanyCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeCompanyCommand(
        string holdingId,
        string id,
        string name,
        string addressCountry,
        string addressPostalCode,
        string addressState,
        string addressStreet,
        string contactFullName,
        string contactEmail,
        string contactPhone
    )
    {
        HoldingId = Parser.ToGuid(holdingId);
        Id = Parser.ToGuid(id);
        Name = name;

        AddressCountry = addressCountry;
        AddressPostalCode = addressPostalCode;
        AddressState = addressState;
        AddressStreet = addressStreet;

        ContactFullName = contactFullName;
        ContactEmail = contactEmail;
        ContactPhone = contactPhone;

        AddNotifications(new ChangeCompanyValidation(this));
        AddNotifications(new CustomNotification().IsGuid(id, "Id", "Id is invalid"));
        AddNotifications(new CustomNotification().IsGuid(holdingId, "HoldingId", "HoldingId is invalid"));
    }
    
    public Guid HoldingId { get; private set; }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public string AddressCountry { get; private set; }
    public string AddressPostalCode { get; private set; }
    public string AddressState { get; private set; }
    public string AddressStreet { get; private set; }

    public string ContactFullName { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }
}