using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using Holding.Core.ValueObjects;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class CreateCompanyCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateCompanyCommand(
        string holdingId,
        string name,
        string addressCountry,
        string addressPostalCode,
        string addressState,
        string addressStreet,
        string contactFullName,
        string contactEmail,
        string contactPhone,
        string role = ""
    )
    {
        HoldingId = holdingId.ToGuid();
        Name = name;

        AddressCountry = addressCountry;
        AddressPostalCode = addressPostalCode;
        AddressState = addressState;
        AddressStreet = addressStreet;

        ContactFullName = contactFullName;
        ContactEmail = contactEmail;
        ContactPhone = contactPhone;

        AddNotifications(new CreateCompanyValidation(this, holdingId, role));
    }

    public Guid HoldingId { get; private set; }
    public string Name { get; private set; }

    public string AddressCountry { get; private set; }
    public string AddressPostalCode { get; private set; }
    public string AddressState { get; private set; }
    public string AddressStreet { get; private set; }

    public string ContactFullName { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhone { get; private set; }

    public Entities.Company ToEntity()
    {
        var address = new Address(AddressCountry, AddressPostalCode, AddressState, AddressStreet);
        var contact = new Contact(ContactFullName, ContactEmail, ContactPhone);
        
        return new Entities.Company(HoldingId, Name, address, contact);
    }
}