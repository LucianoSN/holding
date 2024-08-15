using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class TransferCompanyToAnotherHoldingHandlerTests
{
    private IMediator _bus;

    public TransferCompanyToAnotherHoldingHandlerTests()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }

    private async Task<Holding.Company.Domain.Company.Entities.Company> CreateCompanySut(
        string holdingId,
        string name = "CompanyName",
        string addressCountry = "CountryName",
        string addressPostalCode = "08000000",
        string addressState = "AddressStateName",
        string addressStreet = "AddressStreetName",
        string contactFullName = "ContatctFullName",
        string contactEmail = "valid@email.com",
        string contactPhone = "123456789",
        string role = "SuperAdministrator"
    )
    {
        var command = new CreateCompanyCommand(
            holdingId,
            name,
            addressCountry,
            addressPostalCode,
            addressState,
            addressStreet,
            contactFullName,
            contactEmail,
            contactPhone,
            role
        );

        var result = await _bus.Send(command);
        return result.Data as Holding.Company.Domain.Company.Entities.Company;
    }

    [TestMethod]
    public async Task ShouldReturnValidWhenUpdateIsValid()
    {
        // Arrange
        var newHoldingId = Guid.NewGuid();
        var company = await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new TransferCompanyToAnotherHoldingCommand(
            company.Id.ToString(),
            newHoldingId.ToString(),
            "Master"
        );

        // Act
        var result = await _bus.Send(command);
        var changed = result.Data as Holding.Company.Domain.Company.Entities.Company; 

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(changed.Id, company.Id);
        Assert.AreEqual(changed.HoldingId, newHoldingId);
    }
}