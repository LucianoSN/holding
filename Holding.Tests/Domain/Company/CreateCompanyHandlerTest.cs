using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateCompanyHandlerTest
{
    private ICompanyRepository _repository;
    private readonly CreateCompanyHandler _sut;

    public CreateCompanyHandlerTest()
    {
        _repository = Helper.GetRequiredService<ICompanyRepository>();
        _sut = new CreateCompanyHandler(_repository);
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
        string contactPhone = "123456789"
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
            contactPhone
        );

        return command;
    }
    
    [TestMethod]
    public async Task ShouldCreateCompanyIsInvalid()
    {
        // Arrange
        var command = SutCommand("");

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(result.Success, false);
    }
}