using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Core.DomainObjects.Results;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class TransferCompanyToAnotherHoldingHandler(ICompanyRepository repository)
    : IRequestHandler<TransferCompanyToAnotherHoldingCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(TransferCompanyToAnotherHoldingCommand command, 
        CancellationToken cancellationToken)
    {
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this holding is invalid");

        // Get the company        
        var company = await repository.GetCompanyById(command.CompanyId);

        // Check if the holding exists
        if (company == null)
            return new GenericCommandResult(null, false, "Company not found");
        
        // Update the company
        company.ChangeHolding(command.NewHoldingId);
        
        // Save in the database
        await repository.Update(company);
        await repository.UnitOfWork.Commit();
        
        return new GenericCommandResult(company, true, "Company updated with success");
    }
}