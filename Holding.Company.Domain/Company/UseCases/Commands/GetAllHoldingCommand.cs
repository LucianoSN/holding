using Flunt.Notifications;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class GetAllHoldingCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
{
}
