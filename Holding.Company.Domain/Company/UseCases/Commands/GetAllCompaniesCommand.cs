using Flunt.Notifications;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Commands;

public class GetAllCompaniesCommand : Notifiable<Notification>, IRequest<PagedCommandResult>
{
    public GetAllCompaniesCommand(int currentPage = 1, int pageSize = 25)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public int CurrentPage { get; private set; }    
    public int PageSize { get; private set; }    
}