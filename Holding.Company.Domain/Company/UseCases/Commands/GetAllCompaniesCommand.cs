using Flunt.Notifications;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class GetAllCompaniesCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
    
}