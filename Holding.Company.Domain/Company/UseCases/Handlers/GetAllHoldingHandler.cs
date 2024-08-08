using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class GetAllHoldingHandler(ICompanyRepository repository)
    : IRequestHandler<GetAllHoldingCommand, PagedCommandResult>
{
    public async Task<PagedCommandResult> Handle(GetAllHoldingCommand command, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllHoldings(command.CurrentPage, command.PageSize);

        return new PagedCommandResult(
            companies.Data,
            companies.TotalCount,
            companies.CurrentPage,
            companies.PageSize
        );
    }
}