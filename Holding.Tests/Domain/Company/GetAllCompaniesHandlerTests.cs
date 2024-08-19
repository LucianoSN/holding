using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class GetAllCompaniesHandlerTests
{
    private ICompanyRepository _repository;
    private readonly CreateCompanyHandler _createSut;
    private readonly GetAllCompaniesHandler _getAllSut;

    public GetAllCompaniesHandlerTests()
    {
        _repository = DependencyInjection.Get<ICompanyRepository>();
        _createSut = new CreateCompanyHandler(_repository);
        _getAllSut = new GetAllCompaniesHandler(_repository);
    }
    
    private async Task CreateCompanySut(
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
        if (result.Success) await _repository.UnitOfWork.Commit();
    }
    
    [TestMethod]
    public async Task ShoudReturnInvalidWhenGetAllCompaniesIsEmpty()
    {
        // Arrange
        var command = new GetAllCompaniesCommand(role: "Administrator");
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(result.TotalCount, 0);
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenGetAllCompaniesHasValues()
    {
        // Arrange
        await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new GetAllCompaniesCommand(role: "Administrator");
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreNotEqual(result.TotalCount, 0);
    }
}