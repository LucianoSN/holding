using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class CreateCompanyHandler(ICompanyRepository repository)
    : IRequestHandler<CreateCompanyCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(CreateCompanyCommand command, 
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
        {
            return new GenericCommandResult(command.Notifications, false, "Ops, this company is invalid");
        }
        
        // Generate the Company
        var company = command.ToEntity();
        
        // Save in the database
        await repository.Create(company);
        await repository.Persist.Commit();
        
        return new GenericCommandResult(company, true, "Company created");
    }
}