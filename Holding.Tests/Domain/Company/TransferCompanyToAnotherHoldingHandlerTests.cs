using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class TransferCompanyToAnotherHoldingHandlerTests
{
    private ICompanyRepository _repository;

    private readonly CreateCompanyHandler _createSut;
    private readonly TransferCompanyToAnotherHoldingHandler _tranferSut;

    public TransferCompanyToAnotherHoldingHandlerTests()
    {
        _repository = Helper.GetRequiredService<ICompanyRepository>();
        _createSut = new CreateCompanyHandler(_repository);
        _tranferSut = new TransferCompanyToAnotherHoldingHandler(_repository);
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
        return result.Data as Holding.Company.Domain.Company.Entities.Company;
    }

    [TestMethod]
    public async Task ShouldReturnValidWhenUpdateIsValid()
    {
        // Arrange
        var newHoldingId = Guid.NewGuid();
        var company = await CreateCompanySut(Guid.NewGuid().ToString());
        var command = new TransferCompanyToAnotherHoldingCommand(company.Id.ToString(), newHoldingId.ToString());

        // Act
        var result = await _tranferSut.Handle(command, CancellationToken.None);
        var changed = await _repository.GetCompanyById(company.Id);

        // Assert
        Assert.AreEqual(command.IsValid, true);
        Assert.AreEqual(result.Success, true);
        Assert.AreEqual(changed.Id, company.Id);
        Assert.AreEqual(changed.HoldingId, newHoldingId);
    }
}