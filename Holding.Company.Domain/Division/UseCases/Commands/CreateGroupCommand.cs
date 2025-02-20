using Flunt.Notifications;
using Holding.Company.Domain.Division.UseCases.Commands.Validations;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Helpers;
using MediatR;

namespace Holding.Company.Domain.Division.UseCases.Commands;

public class CreateGroupCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    public CreateGroupCommand(string companyId, string name, string role = "")
    {
        CompanyId = companyId.ToGuid();
        Name = name;

        AddNotifications(new CreateGroupValidation(this, companyId, role));
    }

    public Guid CompanyId { get; private set; }
    public string Name { get; private set; }

    public Entities.Group ToEntity() => new(CompanyId, Name);
}
