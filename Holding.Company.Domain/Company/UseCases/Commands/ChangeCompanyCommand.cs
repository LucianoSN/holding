using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Enumerators;
using Holding.Core.Helpers;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class ChangeCompanyCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public ChangeCompanyCommand(
        string id,
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
        Role = Parser.ToRole(role);
        
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
    }
    
    public Role Role { get; private set; }
    
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