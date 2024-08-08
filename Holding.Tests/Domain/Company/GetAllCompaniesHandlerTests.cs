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
        _repository = Helper.GetRequiredService<ICompanyRepository>();
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

        var result = await _createSut.Handle(command, CancellationToken.None);
        if (result.Success) await _repository.Transact.Commit();
        
        await _repository.GetCompanyById((result.Data as Holding.Company.Domain.Company.Entities.Company).Id);
    }
    
    [TestMethod]
    public async Task ShoudReturnInvalidWhenGetAllCompaniesIsEmpty()
    {
        // Arrange
        var command = new GetAllCompaniesCommand();
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
        var total = (result.Data as List<Holding.Company.Domain.Company.Entities.Company>).Count();
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(total, 0);
    }

    [TestMethod]
    public async Task ShoudReturnValidWhenGetAllCompaniesHasValues()
    {
        // Arrange
        await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new GetAllCompaniesCommand();
    
        // Act
        var result = await _getAllSut.Handle(command, CancellationToken.None);
        var total = (result.Data as List<Holding.Company.Domain.Company.Entities.Company>).Count();
    
        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreNotEqual(total, 0);
    }
}