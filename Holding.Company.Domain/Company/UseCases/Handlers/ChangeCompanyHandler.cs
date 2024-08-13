using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers.Permissions;
using Holding.Core.DomainObjects.Results;
using Holding.Core.ValueObjects;
using MediatR;

namespace Holding.Company.Domain.Company.UseCases.Handlers;

public class ChangeCompanyHandler(ICompanyRepository repository)
    : IRequestHandler<ChangeCompanyCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> Handle(ChangeCompanyCommand command,
        CancellationToken cancellationToken)
    {
        // Check permissions
        if (!new ChangeCompanyPermission().HasPermission(command.Role))
            return new GenericCommandResult(null, false, "You do not have permission to perform this action");
        
        // Fast Fail Validation
        if (!command.IsValid)
            return new GenericCommandResult(command.Notifications, false, "Ops, this holding is invalid");

        // Get the company        
        var company = await repository.GetCompanyById(command.Id);

        // Check if the holding exists
        if (company == null)
            return new GenericCommandResult(null, false, "Company not found");

        // Update the company
        company.ChangeName(command.Name);

        company.ChangeAddress(
            new Address(
                command.AddressCountry,
                command.AddressPostalCode,
                command.AddressState,
                command.AddressStreet)
        );
        
        company.ChangeContact(
            new Contact(
                command.ContactFullName,
                command.ContactEmail,
                command.ContactPhone)
        );
        
        // Save in the database
        await repository.Update(company);
        await repository.Transact.Commit();
        
        return new GenericCommandResult(company, true, "Company updated with success");
    }
}