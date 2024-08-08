using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class GetAllCompaniesHandler(ICompanyRepository repository)
    : IRequestHandler<GetAllCompaniesCommand, PagedCommandResult>
{
    public async Task<PagedCommandResult> Handle(GetAllCompaniesCommand command, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllCompanies(command.CurrentPage, command.PageSize);

        return new PagedCommandResult(
            companies.Data,
            companies.TotalCount,
            companies.CurrentPage,
            companies.PageSize
        );
    }
}