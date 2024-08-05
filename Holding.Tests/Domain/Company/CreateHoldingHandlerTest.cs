using Holding.Company.Domain.Company.Queries;
using Holding.Company.Domain.Company.UseCases.Commands;
using Holding.Company.Domain.Company.UseCases.Handlers;
using Holding.Data.Contexts;
using Holding.Data.Repositories;

namespace Holding.Tests.Domain.Company;

[TestClass]
public class CreateHoldingHandlerTest
{
    private readonly CreateHoldingHandler _sut;
    private DataContext _dataContext;
    private ICompanyRepository _repository;

    public CreateHoldingHandlerTest()
    {
        _dataContext = new DataContext();
        _repository = new CompanyRepository(_dataContext);
        _sut = new CreateHoldingHandler(_repository);
    }

    [TestMethod]
    public async Task ShouldCreateHoldingIsValid()
    {
        // Arrange
        var command = new CreateHoldingCommand("Holding Test", "Holding Test Description");

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);
        if (result.Success) await _dataContext.Commit();

        var holdings = await _repository.GetHoldingById((result.Data as Holding.Company.Domain.Company.Entities.Holding).Id);

        // Assert
        Assert.AreEqual(result.Success, true);
        Assert.IsNotNull(holdings);
    }
} 