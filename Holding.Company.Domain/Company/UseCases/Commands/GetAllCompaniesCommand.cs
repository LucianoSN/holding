using Flunt.Notifications;
using Holding.Company.Domain.Company.UseCases.Commands.Permissions;
using Holding.Core.DomainObjects.Results;
using Holding.Core.Validations.Notifications;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class GetAllCompaniesCommand : Notifiable<Notification>, IRequest<PagedCommandResult>
{
    public GetAllCompaniesCommand(int currentPage = 1, int pageSize = 25, string role = "")
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        
        AddNotifications(new CustomNotification().HasPermission<GetAllCompaniesPermission>(role));
    }

    public int CurrentPage { get; private set; }    
    public int PageSize { get; private set; }    
}