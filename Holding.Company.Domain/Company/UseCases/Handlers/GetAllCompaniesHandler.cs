using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class GetAllCompaniesHandler(ICompanyRepository repository)
    : IRequestHandler<GetAllCompaniesCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllHoldings();
        return new GenericCommandResult(companies, true, "Companies retrieved with success");
    }
}