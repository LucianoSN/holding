using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class ChangeCompanyHandlerTests
{
    private IMediator _bus;

    public ChangeCompanyHandlerTests()
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
    public async Task ShoudReturnValidWhenUpdateIsValid()
    {
        // Arrange
        var company = await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new ChangeCompanyCommand(
            company.Id.ToString(),
            "NewCompanyName",
            "NewCountryName",
            "02000000",
            "NewAddressStateName",
            "NewAddressStreetName",
            "NewContatctFullName",
            "changed@email.com",
            "987654321",
            "SuperAdministrator"
        );

        // Act
        var result = await _bus.Send(command);
        var changed = result.Data as Holding.Company.Domain.Company.Entities.Company;

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(company.Id, changed.Id);
        Assert.AreEqual(company.Name, changed.Name);
        Assert.AreEqual(company.Address.Country, changed.Address.Country);
        Assert.AreEqual(company.Address.PostalCode, changed.Address.PostalCode);
        Assert.AreEqual(company.Address.State, changed.Address.State);
        Assert.AreEqual(company.Address.Street, changed.Address.Street);
        Assert.AreEqual(company.Contact.FullName, changed.Contact.FullName);
        Assert.AreEqual(company.Contact.Email, changed.Contact.Email);
        Assert.AreEqual(company.Contact.Phone, changed.Contact.Phone);
        Assert.AreEqual(company.HoldingId, changed.HoldingId);
    }
}