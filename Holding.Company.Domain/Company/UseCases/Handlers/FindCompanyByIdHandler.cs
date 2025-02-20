using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class FindCompanyByIdHandler(ICompanyRepository repository)
    : IRequestHandler<FindCompanyByIdCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(
        FindCompanyByIdCommand command,
        CancellationToken cancellationToken
    )
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(
                command.Notifications,
                false,
                "Ops, this company is invalid"
            );

        // Get the holding
        var company = await repository.GetCompanyById(command.Id);

        // Check if the holding exists
        if (company == null)
            return new GenericCommandResult(null, false, "Company not found");

        return new GenericCommandResult(company, true, "Company found with success");
    }
}
