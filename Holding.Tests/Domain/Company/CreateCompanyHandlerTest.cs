using Holding.Company.Domain.Company.UseCases.Commands;
using MediatR;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateCompanyHandlerTest
{
    private IMediator _bus;

    public CreateCompanyHandlerTest()
    {
        _bus = DependencyInjection.Get<IMediator>();
    }
    
    private static CreateCompanyCommand SutCommand(
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

        return command;
    }
    
    [TestMethod]
    public async Task ShouldCreateCompanyIsInvalid()
    {
        // Arrange
        var command = SutCommand("");

        // Act
        var result = await _bus.Send(command);

        // Assert
        Assert.AreEqual(result.Success, false);
    }
    
    [TestMethod]
    public async Task ShouldCreateCompanyIsValid()
    {
        // Arrange
        var command = SutCommand(Guid.NewGuid().ToString());

        // Act
        var result = await _bus.Send(command, CancellationToken.None);
        var company = result.Data as Holding.Company.Domain.Company.Entities.Company;

        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(company);
    }
}