using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class GetAllHoldingHandler(ICompanyRepository repository)
    : IRequestHandler<GetAllHoldingCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(GetAllHoldingCommand command, CancellationToken cancellationToken)
    {
        var holdings = await repository.GetAllHoldings();
        return new GenericCommandResult(holdings, true, "Holdings retrieved with success");
    }
}