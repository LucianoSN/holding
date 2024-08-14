using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class FindCompanyByIdHandlerTests
{
    private ICompanyRepository _repository;
    private readonly CreateCompanyHandler _createSut;
    private readonly FindCompanyByIdHandler _findSut;

    public FindCompanyByIdHandlerTests()
    {
        _repository = Helper.GetRequiredService<ICompanyRepository>();
        _createSut = new CreateCompanyHandler(_repository);
        _findSut = new FindCompanyByIdHandler(_repository);
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

        var result = await _createSut.Handle(command, CancellationToken.None);
        
        return await _repository.GetCompanyById((result.Data as Holding.Company.Domain.Company.Entities.Company).Id);
    }
    
    [TestMethod]
    public async Task ShoudReturnValidWhenFindCompanyByIdIsValid()
    {
        // Arrange
        var company = await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new FindCompanyByIdCommand(company.Id.ToString());

        // Act
        var result = await _findSut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
    }
    
    [TestMethod]
    public async Task ShoudReturnInvalidWhenFindHoldingByIdNotFound()
    {
        // Arrange
        var command = new FindCompanyByIdCommand(Guid.NewGuid().ToString());

        // Act
        var result = await _findSut.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, false);
        Assert.IsNull(result.Data);
    }
}